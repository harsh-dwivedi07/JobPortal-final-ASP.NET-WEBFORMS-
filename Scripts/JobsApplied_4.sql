CREATE TABLE [JobPortal].[dbo].[JobsApplied](
	JobId uniqueidentifier,
	UserId uniqueidentifier ,
  CompanyName nvarchar(50),
  Status Integer,
 CreatedAt DateTime,
   PRIMARY KEY (JobId,UserId),
   FOREIGN KEY(UserId) references  [JobPortal].[dbo].[JobSeeker](UserId),
   FOREIGN KEY(JobId) references  [JobPortal].[dbo].[JobDetails](JobId)
	);