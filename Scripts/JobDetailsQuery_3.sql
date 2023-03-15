CREATE TABLE [JobPortal].[dbo].[JobDetails](
	JobId uniqueidentifier,
	UserId uniqueidentifier ,
  CompanyName nvarchar(50),
  CompanyLocation nvarchar(50),
  JobDescription nvarchar(max),
  JobTitle nvarchar(50),
  CreatedAt DateTime,
  UpdatedAt DateTime,
  isActive Integer default 1,
   PRIMARY KEY (JobId),
   FOREIGN KEY(UserId) references  [JobPortal].[dbo].[JobRecruiter](UserId)
	);