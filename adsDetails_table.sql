use bangladeshtoday

create table adsdetails
(
	id int primary key identity,
	companyName nvarchar(200),
	companyAddress nvarchar(500),
	companyurl nvarchar(500),
	picture nvarchar(max),
	title nvarchar(500),
	[description] nvarchar(max),
	startDate datetime,
	endDate datetime,
	dailyRate money,
	totalPrice money
)






CREATE TABLE sysUser  
(  
FirstName VARCHAR(20) NOT NULL,  
LastName VARCHAR(20) NOT NULL,  
UserID VARCHAR(20) PRIMARY KEY,  
UserPassword VARCHAR(20) NOT NULL  
)


GO

CREATE PROCEDURE spRegisterUser  
(  
    @FirstName VARCHAR(20),  
    @LastName VARCHAR(20) ,  
    @UserID VARCHAR(20) ,  
    @UserPassword VARCHAR(20)   
)  
AS  
BEGIN  
    DECLARE @result VARCHAR(10) ='Failed'
    IF NOT EXISTS(SELECT 1 FROM sysUser where UserID=@UserID)  
    BEGIN     
        INSERT INTO sysUser  
        VALUES   
        (   
            @FirstName,@LastName,@UserID,@UserPassword  
        )  
        SET @result= 'Success'  
    END   
        SELECT @result AS Result  
END


go

CREATE PROCEDURE spValidateUserLogin  
(  
    @LoginID VARCHAR(20) ,  
    @LoginPassword VARCHAR(20)  
)  
AS  
BEGIN  
    DECLARE @authentication VARCHAR(10)='Failed'  
    IF EXISTS(SELECT 1 FROM sysUser WHERE UserID=@LoginID AND UserPassword =@LoginPassword)  
    BEGIN  
        SET @authentication='Success'  
    END  
    SELECT @authentication AS isAuthenticated  
END

