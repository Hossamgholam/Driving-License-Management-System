
insert into LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)values(@ApplicationID,@LicenseClassID);
select SCOPE_IDENTITY();
delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;


select 1 from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID

update LocalDrivingLicenseApplications 
set ApplicationID=@NewApplicationID ,LicenseClassID=NewLicenseClassID 
where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID

select* from LocalDrivingLicenseApplications

select A.ApplicationID,Lc.ClassName,P.FirstName+' '+P.SecondName+' '+P.ThirdName+' '+P.LastName as [Full Name],
A.ApplicationDate
from LocalDrivingLicenseApplications L inner join Applications A
on L.ApplicationID=A.ApplicationID
inner join LicenseClasses LC
on L.LicenseClassID=LC.LicenseClassID
inner join Person P
on A.ApplicantPersonID=P.PersonID


