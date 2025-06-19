CREATE PROCEDURE [Security].[UserSet] 
    @idUser int = null,
    @Email nvarchar(100),
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
	@birthday datetimeoffset,
    @Active bit,   
	@roles Common.TId readonly,
	@inputByIdUser int
AS
 BEGIN
 	declare @returnValue int= 1

	-- Insert normal cuando no pasamos el Id
	if(@idUser is null)								
	 begin
		-- Validamos que no exista el email
		if(exists(select * from [Security].[User] where Email = @Email))	
		 begin
			-- si existe regresamos el -101
			set @returnValue =  -101
		 end
		else
		 begin
			-- si no existe lo insertamos
			INSERT INTO [Security].[User](Email, FirstName, LastName, Birthday, CreationDateTime, CreatedByIdUser)
											 VALUES(@Email, @FirstName, @LastName, @birthday, SYSDATETIMEOFFSET(), @inputByIdUser);

			set @idUser = SCOPE_IDENTITY()
			exec [Security].[UserRoleSet] @idUser, @roles, @inputByIdUser
		 end
	 end
	else
	-- Al existir el user entonces pasamos un idUser
	 begin
		-- si no existe el idUser
		if(not exists(select * from [Security].[User] where idUser = @idUser))	
		 begin
			-- regresamos el -102 porque estamos intentando actualizar un id que no existe
			set @returnValue =  -102
		 end
		else
		 begin
			-- si queremos modificar el email con un email que ya existe, validamos que no este duplicado
			if(exists(select * from [Security].[User] where Email = @Email and idUser <> @idUser))
			 begin				
				-- regresamos que ya existe con el -101
				set @returnValue =  -101
			 end
			else
			-- si no existe duplicado lo actualizamos
			 begin												
				UPDATE [Security].[User] SET Email = @Email, FirstName = @FirstName, LastName = @LastName, Birthday = @birthday,
													   Active = @Active, UpdateDateTime = SYSDATETIMEOFFSET(), UpdatedByIdUser = @inputByIdUser
												 WHERE idUser = @idUser

				exec [Security].[UserRoleSet] @idUser, @roles, @inputByIdUser

			 end
		 end
	 end

	 select @returnValue
END