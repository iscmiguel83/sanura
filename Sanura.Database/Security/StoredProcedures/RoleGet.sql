CREATE PROCEDURE [Security].[RoleGet]
	@idRole int = null,
	@Code nvarchar(50)=null,
	@active bit = null,
	@pageNumber int= 1,
	@pageSize int= 100,
	@orderByColumn VARCHAR(80) = null,   
	@sortType TINYINT = 0
 AS
BEGIN
	SET @orderByColumn = UPPER(@orderByColumn);	

	DECLARE @table table(rowNumber int not null,
						 idRole int not null,
						 Code nvarchar(50) not null,
						 Description nvarchar(100) not null,
						 Active bit not null,
						 CreationDateTime datetimeoffset not null,
						 CreatedByIdUser int not null,
						 UpdateDateTime datetimeoffset null,
						 UpdateByIdUser int null
						)
	insert into @table
	SELECT ROW_NUMBER() OVER
				   (
					ORDER BY    
						CASE when @sortType = 1 then ''					WHEN @orderByColumn is NULL					then idRole					end asc   
					   ,CASE when @sortType = 0 then ''					WHEN @orderByColumn IS NULL					then idRole					end desc
					   ,CASE when @sortType = 1 then ''					WHEN @orderByColumn = 'CODE'				then Code					end asc   
					   ,CASE when @sortType = 0 then ''					WHEN @orderByColumn = 'CODE'				then Code					end desc    
				   ), 
				   * 
			  from [Security].[Role]
	where 
			(@idRole is null or idRole = @idRole)
		and (@Code is null or Code = @Code)
		and (@active is  null or [Active] = @active)

	declare @initialId int = ((@pageNumber-1) * @pageSize) +1
	declare @finalId int = (@pageNumber) * @pageSize

	if(@pageNumber = 0)
		select @finalId =count(rowNumber) from @table

	select *
		from @table
		where rowNumber >= @initialId and rowNumber<= @finalId

	select distinct * from
	(
		select u.* from [Security].[User] u
		inner join @table t on t.CreatedByIdUser = u.idUser
		where rowNumber >= @initialId and rowNumber<= @finalId
		union
		select u.* from [Security].[User] u
		inner join @table t on t.UpdateByIdUser = u.idUser
		where rowNumber >= @initialId and rowNumber<= @finalId
	) users

	select distinct rm.*
			from [Security].[RoleModule] rm
	  inner join @table t on t.idRole = rm.idRole
		   where rowNumber >= @initialId and rowNumber<= @finalId

	select distinct m.*
			from [Security].[RoleModule] rm
	  inner join @table t on t.idRole = rm.idRole
	  inner join [Security].[Module] m on m.idModule = rm.idModule
		   where rowNumber >= @initialId and rowNumber<= @finalId

	select count(rowNumber) [count] from @table
END