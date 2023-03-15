CREATE TABLE [JobPortal].[dbo].[JobSeeker](
	UserId uniqueidentifier,
  firstName nvarchar(50),
  lastName nvarchar(50),
  Email nvarchar(50),
  Mobile nvarchar(50),
  DOB DateTime,
  CurrentLocation nvarchar(50),
  About nvarchar(max),
  Experience Integer Default 0,
  CreatedAt DateTime,
  UpdatedAt DateTime,
   PRIMARY KEY (UserId),
	);