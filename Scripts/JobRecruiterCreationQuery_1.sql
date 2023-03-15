

  Create Table [JobPortal].[dbo].[JobRecruiter] (
  UserId uniqueidentifier,
  firstName nvarchar(50),
  lastName nvarchar(50),
  Email nvarchar(50),
  Mobile nvarchar(50),
  DOB DateTime,
  CompanyName nvarchar(50),
  CreatedAt DateTime,
  UpdatedAt DateTime,
   PRIMARY KEY (UserId),
  );