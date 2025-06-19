CREATE Procedure [Security].[RoleModuleSet]
    @idRole int,
	@modules Common.TId readonly,
	@inputByIdUser int
AS
 BEGIN
 	declare @returnValue int= 1

	MERGE [Security].[RoleModule] AS Target
	USING (select @idRole as idRole, id as idModule
		    from  @modules) AS Source
	ON Target.idRole = source.idRole and Target.idModule = source.idModule
	WHEN NOT MATCHED THEN
		INSERT (idRole, idModule, CreationDateTime, CreatedByIdUser) 
		VALUES (Source.idRole, Source.idModule, SYSDATETIMEOFFSET(), @inputByIdUser)
	When matched then
		Update set Target.Active = 1,
				   Target.UpdateDateTime = SYSDATETIMEOFFSET(), 
				   Target.UpdatedByIdUser = @inputByIdUser				 
	When not matched by Source and target.idRole = @idRole  then
		update set Target.Active = 0;

	select @returnValue
END
GO

