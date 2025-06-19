CREATE PROCEDURE [Security].[UserGet]
	@idUser int = null,
	@Email nvarchar(100)=null,
	@FirstName nvarchar(50)=null,
	@LastName nvarchar(50)=null,
	@active bit = null,
	@pageNumber int= 1,
	@pageSize int= 100,
	@orderByColumn nvarchar(80) = null,   
	@sortType TINYINT = 0
 AS
BEGIN
	SET @orderByColumn = UPPER(@orderByColumn);	

	DECLARE @table table(rowNumber int not null,
						 idUser int not null,
						 Email nvarchar(100) not null,
						 FirstName nvarchar(50) null,
						 LastName nvarchar(50) null,
						 birthday datetimeoffset null,
						 Active bit not null,
						 CreationDateTime datetimeoffset not null,
						 CreatedByIdUser int not null,
						 UpdateDateTime datetimeoffset null,
						 UpdatedByIdUser int null
						)
	insert into @table
	SELECT ROW_NUMBER() OVER
				   (
					ORDER BY    
						CASE when @sortType = 1 then ''					WHEN @orderByColumn is NULL					then idUser					end asc   
					   ,CASE when @sortType = 0 then ''					WHEN @orderByColumn IS NULL					then idUser					end desc
					   ,CASE when @sortType = 1 then ''					WHEN @orderByColumn = 'EMAIL'				then Email					end asc   
					   ,CASE when @sortType = 0 then ''					WHEN @orderByColumn = 'EMAIL'				then Email					end desc    
					   ,CASE when @sortType = 1 then ''					WHEN @orderByColumn = 'FIRSTNAME'			then FirstName				end asc   
					   ,CASE when @sortType = 0 then ''					WHEN @orderByColumn = 'FIRSTNAME'			then FirstName				end desc  
					   ,CASE when @sortType = 1 then ''					WHEN @orderByColumn = 'LASTNAME'			then LastName				end asc   
					   ,CASE when @sortType = 0 then ''					WHEN @orderByColumn = 'LASTNAME'			then LastName				end desc  
				   ), 
				   * 
			  from [Security].[User]
	where 
			(@idUser is null or idUser = @idUser)
		and (@Email is null or Email = @Email)
		and (@FirstName is null or FirstName = @FirstName)
		and (@LastName is null or LastName = @LastName)
		and (@active is  null or [Active] = @active)

	declare @initialId int = ((@pageNumber-1) * @pageSize) +1
	declare @finalId int = (@pageNumber) * @pageSize

	if(@pageNumber = 0)
		select @finalId =count(rowNumber) from @table

	select *
		from @table
		where rowNumber >= @initialId and rowNumber<= @finalId

	--select distinct * from
	--(
	--	select u.* from [Security].[User] u
	--	inner join @table t on t.CreatedByIdUser = u.idUser
	--	where rowNumber >= @initialId and rowNumber<= @finalId
	--	union
	--	select u.* from [Security].[User] u
	--	inner join @table t on t.UpdatedByIdUser = u.idUser
	--	where rowNumber >= @initialId and rowNumber<= @finalId
	--) users

	select distinct ur.*
			from [Security].[UserRole] ur
	  inner join @table t on t.idUser = ur.idUser
		   where rowNumber >= @initialId and rowNumber<= @finalId

	select distinct r.*
			from [Security].[UserRole] ur
	  inner join @table t on t.idUser = ur.idUser
	  inner join [Security].[Role] r on r.idRole = ur.idRole
		   where rowNumber >= @initialId and rowNumber<= @finalId
	select count(rowNumber) [count] from @table
END