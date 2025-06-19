CREATE PROCEDURE [Security].[ModuleSet] 
    @idModule int = null,
    @idModuleParent int,
    @Code nvarchar(50),
    @Description nvarchar(100),
    @SortOrder float,
    @Icon nvarchar(50),
    @Active bit,
    @inputByIdUser int
AS
 BEGIN
	declare @returnValue int= 1

	-- Insert normal cuando no pasamos el Id
	if(@idModule is null)								
	 begin
		-- Validamos que no exista el code
		if(exists(select * from Security.Module where Code = @Code))
		 begin
			-- si existe regresamos el -101
			set @returnValue =  -101
		 end
		else
		 begin
			-- si no existe lo insertamos
			INSERT INTO [Security].[Module](idModuleParent, Code, Description, SortOrder, Icon, CreationDateTime, CreatedByIdUser)
                             VALUES(@idModuleParent, @Code, @Description, @SortOrder, @Icon, SYSDATETIMEOFFSET(), @inputByIdUser);
		 end
	 end
	else
	-- Al existir el module entonces pasamos un idModule
	 begin
		-- si no existe el idModule
		if(not exists(select * from Security.Module where idModule = @idModule))
		 begin
			-- regresamos el -102 porque estamos intentando actualizar un id que no existe
			set @returnValue =  -102
		 end
		else
		 begin
			-- si queremos modificar el code con un code que ya existe, validamos que no este duplicado
			if(exists(select * from Security.Module where Code = @Code and idModule <> @idModule))
			 begin				
				-- regresamos que ya existe con el -101
				set @returnValue =  -101
			 end
			else
			-- si no existe duplicado lo actualizamos
			 begin												
				UPDATE [Security].[Module] SET idModuleParent = @idModuleParent, Code = @Code, Description = @Description, SortOrder = @SortOrder, Icon = @Icon,
											   Active = @Active, UpdateDateTime = Sysdatetimeoffset(), UpdatedByIdUser = @inputByIdUser
										 WHERE idModule = @idModule
			 end
		 end
	 end

	 select @returnValue
END