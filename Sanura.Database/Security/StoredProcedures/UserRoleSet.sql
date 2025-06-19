Create Procedure [Security].[UserRoleSet]
    @idUser int,
	@roles Common.TId readonly,
	@inputByIdUser int
AS
 BEGIN
 	declare @returnValue int= 1

	MERGE [Security].[UserRole] AS Target
	USING (select @idUser as idUser, id as idRole
		    from  @roles) AS Source
	ON Target.idUser = source.idUser and Target.idRole = source.idRole
	WHEN NOT MATCHED THEN
		INSERT (idUser, idRole, CreationDateTime, CreatedByIdUser) 
		VALUES (Source.idUser, Source.idRole, SYSDATETIMEOFFSET(), @inputByIdUser)
	When matched then
		Update set Target.Active = 1,
				   Target.UpdateDateTime = SYSDATETIMEOFFSET(), 
				   Target.UpdatedByIdUser = @inputByIdUser				 
	When not matched by Source and target.idUser = @idUser  then
		update set Target.Active = 0;

	select @returnValue
END
GO

