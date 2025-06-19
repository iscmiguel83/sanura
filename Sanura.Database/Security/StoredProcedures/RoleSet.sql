CREATE PROCEDURE [Security].[RoleSet] 
    @idRole int=null,
    @Code nvarchar(50),
    @Description nvarchar(100),
    @Active bit,
	@modules Common.TId readonly,
	@inputByIdUser int
AS
 BEGIN
	declare @returnValue int= 1

	-- Insert normal cuando no pasamos el Id
	if(@idRole is null)								
	 begin
		-- Validamos que no exista el email
		if(exists(select * from Security.Role where Code = @Code))
		 begin
			-- si existe regresamos el -101
			set @returnValue =  -101
		 end
		else
		 begin
			-- si no existe lo insertamos
			INSERT INTO [Security].[Role](Code, Description, CreationDateTime, CreatedByIdUser)
								   VALUES(@Code, @Description, sysdatetimeoffset(), @inputByIdUser);
			
			set @idRole = SCOPE_IDENTITY()
			exec [Security].[RoleModuleSet] @idRole, @modules, @inputByIdUser
		 end
	 end
	else
	-- Al existir el role entonces pasamos un idRole
	 begin
		-- si no existe el idRole
		if(not exists(select * from Security.Role where idRole = @idRole))
		 begin
			-- regresamos el -102 porque estamos intentando actualizar un id que no existe
			set @returnValue =  -102
		 end
		else
		 begin
			-- si queremos modificar el code con un code que ya existe, validamos que no este duplicado
			if(exists(select * from Security.Role where Code = @Code and idRole <> @idRole))
			 begin				
				-- regresamos que ya existe con el -101
				set @returnValue =  -101
			 end
			else
			-- si no existe duplicado lo actualizamos
			 begin												
				UPDATE [Security].[Role] SET Code = @Code, Description = @Description,
											 Active = @Active, UpdateDateTime = SYSDATETIMEOFFSET(), UpdatedByIdUser = @inputByIdUser
									   WHERE idRole = @idRole

				exec [Security].[RoleModuleSet] @idRole, @modules, @inputByIdUser
			 end
		 end
	 end

	 select @returnValue
END