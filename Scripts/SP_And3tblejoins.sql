/****** Script for SelectTopNRows command from SSMS  ******/
Use JobPortal
Go

Alter Procedure proc_getAllSeekersForCompany(@companyname AS NVARCHAR(50))
As
Begin
	Select * From [JobPortal].[dbo].[JobSeeker] where UserId in (SELECT a.UserId
  FROM [JobPortal].[dbo].[JobsApplied] as a Inner Join [JobPortal].[dbo].[JobDetails] as b
  On a.JobId=b.JobId where b.CompanyName=@companyname);
End;

exec proc_getAllSeekersForCompany @companyname='Company11';