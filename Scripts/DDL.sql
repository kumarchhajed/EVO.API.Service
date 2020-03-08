If(db_id(N'EvoOnline') IS NULL)
BEGIN
	CREATE DATABASE EvoOnline
END

IF object_id('ContactInformation', 'U') IS NULL
BEGIN
	CREATE TABLE dbo.ContactInformation
	(
		  ID INT IDENTITY(1,1) PRIMARY KEY
		, FirstName VARCHAR(100) NOT NULL
		, LastName VARCHAR(100) NOT NULL
		, Email VARCHAR(200)
		, PhoneNumber VARCHAR(20) 
		, [Status] BIT NOT NULL
	)
END
GO

