create database MYDVld


create table Countries(
  CountryID int primary key ,
  CountryName nvarchar(50)

 )
 ALTER TABLE Countries
ALTER COLUMN CountryName VARCHAR(50) NOT NULL;

 create table Person(
  PersonID int primary key identity(1,1),
  NationalNo nvarchar(20) not null,
  secondName nvarchar(2) not null,
  ThirdName nvarchar(20) ,
  LastName nvarchar(20) not null,
  DateOfBirth dateTime not null,
  Gender tinyint not null,
  Address nvarchar(500) not null,
  phone nvarchar(20) not null,
  Email nvarchar(50)not null,
  imagePath nvarchar(500),
  NationalityCountryID int not null,
  constraint FK_People_Countries foreign key (NationalityCountryID) references Countries(CountryID)
  )
  alter table Person add FristName nvarchar(20) not null
  alter table Person alter column secondName nvarchar(20) not null
   


  Create Table Users(
   UserID int primary key identity(1,1),
   UserName nvarchar(20) not null,
   Password nvarchar(20) not null,
   ISActive bit ,
   PersonId int not null,
   constraint FK_Users_People foreign key(PersonID) references Person(PersonID)
   )


   create table ApplicationTypes(
    ApplicationTypeID int identity(1,1) primary key,
    ApplicatinTypeTitle nvarchar(150) not null,
    ApplicationFees smallMoney not null
    )

    create table LicenseClasses(
    LicenseClassID int identity(1,1) primary key,
    ClassName nvarchar(50) not null,
    ClassDescription nvarchar(500) not null,
    MinimumAllowedAge tinyint not null,
    ValidityLength  tinyint not null,
    ClassFees smallmoney not null
    )

    create table Applications(
    ApplicationID int identity(1,1) primary key,
    PersonID int not null,
    CreatedByUserID int not null ,
    ApplicationTypeID int not null,
    ApplicationDate datetime not null,
    ApplicationStatus tinyint not null,
    PaidFees smallmoney not null,
    LastStatusDate datetime not null,
    constraint Fk_applications_user foreign key(CreatedByUserID) references Users(UserID),
    constraint Fk_applications_Person foreign key(PersonID) references Person(PersonID),
    constraint Fk_applications_ApplicationTypes foreign key(ApplicationTypeID) references ApplicationTypes(ApplicationTypeID),


    )


    Create table LocalDrivingLicenseApplication(

    LocalDrivingLicenseApplicationID int identity(1,1) primary key,
    LicenseClassID int not null ,
    ApplicationID int not null
    constraint FK_LocalDrivingLicenseApplication_LicenseClass foreign key(LicenseClassID) references LicenseClasses(LicenseClassID),
    constraint FK_LocalDrivingLicenseApplication_Applications foreign key(ApplicationID) references Applications(ApplicationID)
    )

    create table  TestTypes (
     TestTypeID int identity(1,1) primary key,
     TestTypeTitle nvarchar(100) not null,
     TestTypeDescription nvarchar(500) not null,
     TestFees smallmoney not null
     )

    CREATE TABLE TestAppointments(
    TestAppointmentID INT IDENTITY(1,1) PRIMARY KEY,
    TestTypeID INT NOT NULL,
    LocalDrivingLicenseApplicationID INT NOT NULL,
    CreatedByUserID INT NOT NULL,
    RetakeTestApplicationID INT NULL,

    AppointmentDate DATETIME NOT NULL,
    PaidFees smallmoney  NOT NULL,
    IsLocked BIT NOT NULL DEFAULT 0,


    CONSTRAINT FK_TestAppointments_TestTypes
        FOREIGN KEY(TestTypeID)
        REFERENCES TestTypes(TestTypeID),

    CONSTRAINT FK_TestAppointments_LDLA
        FOREIGN KEY(LocalDrivingLicenseApplicationID)
        REFERENCES LocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID),

    CONSTRAINT FK_TestAppointments_Users
        FOREIGN KEY(CreatedByUserID)
        REFERENCES Users(UserID),

    CONSTRAINT FK_TestAppointments_RetakeApplication
        FOREIGN KEY(RetakeTestApplicationID)
        REFERENCES Applications(ApplicationID)
);


CREATE TABLE Tests(
    TestID INT IDENTITY(1,1) PRIMARY KEY,
    TestAppointmentID INT NOT NULL UNIQUE,
    CreatedByUserID INT NOT NULL,
  
    TestResult BIT NOT NULL,
    Notes NVARCHAR(500),


    CONSTRAINT FK_Tests_TestAppointments
        FOREIGN KEY(TestAppointmentID)
        REFERENCES TestAppointments(TestAppointmentID),

    CONSTRAINT FK_Tests_Users
        FOREIGN KEY(CreatedByUserID)
        REFERENCES Users(UserID)
);




CREATE TABLE Drivers
(
    DriverID INT IDENTITY(1,1) PRIMARY KEY,
    PersonID INT NOT NULL UNIQUE,
    CreatedByUserID INT NOT NULL,

    CreatedDate smalldatetime NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Drivers_People
        FOREIGN KEY(PersonID)
        REFERENCES Person(PersonID),

    CONSTRAINT FK_Drivers_Users
        FOREIGN KEY(CreatedByUserID)
        REFERENCES Users(UserID)
);


    CREATE TABLE Licenses(
    LicenseID INT IDENTITY(1,1) PRIMARY KEY,
    DriverID INT NOT NULL,
    CreatedByUserID INT NOT NULL,
    LicenseClassID INT NOT NULL,
    ApplicationID INT NOT NULL,

    IssueDate DATETime NOT NULL,
    ExpirationDate DATETime NOT NULL,
    Notes NVARCHAR(500),
    IssueReason TINYINT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    PaidFees SmallMoney NOT NULL,



    CONSTRAINT FK_Licenses_Applications
        FOREIGN KEY(ApplicationID)
        REFERENCES Applications(ApplicationID),

    CONSTRAINT FK_Licenses_Drivers
        FOREIGN KEY(DriverID)
        REFERENCES Drivers(DriverID),

    CONSTRAINT FK_Licenses_LicenseClasses
        FOREIGN KEY(LicenseClassID)
        REFERENCES LicenseClasses(LicenseClassID),

    CONSTRAINT FK_Licenses_Users
        FOREIGN KEY(CreatedByUserID)
        REFERENCES Users(UserID)
);

    CREATE TABLE DetainedLicenses(
    DetainID INT IDENTITY(1,1) PRIMARY KEY,
    LicenseID INT NOT NULL,
    CreatedByUserID INT NOT NULL,
    ReleasedByUserID INT NULL,
    ReleaseApplicationID INT NULL,

    DetainDate smalldatetime NOT NULL,
    FineFees smalldatetime NOT NULL,
    IsReleased BIT NOT NULL DEFAULT 0,
    ReleaseDate smalldatetime NULL,


    CONSTRAINT FK_DetainedLicenses_Licenses
        FOREIGN KEY(LicenseID)
        REFERENCES Licenses(LicenseID),

    CONSTRAINT FK_DetainedLicenses_CreatedUser
        FOREIGN KEY(CreatedByUserID)
        REFERENCES Users(UserID),

    CONSTRAINT FK_DetainedLicenses_ReleasedUser
        FOREIGN KEY(ReleasedByUserID)
        REFERENCES Users(UserID),

    CONSTRAINT FK_DetainedLicenses_Applications
        FOREIGN KEY(ReleaseApplicationID)
        REFERENCES Applications(ApplicationID)
);


CREATE TABLE InternationalLicenses
(
    InternationalLicenseID INT IDENTITY(1,1) PRIMARY KEY,
    CreatedByUserID INT NOT NULL,
    DriverID INT NOT NULL,
    IssuedUsingLocalLicenseID INT NOT NULL,
    ApplicationID INT NOT NULL,

    IssueDate SmallDatetime NOT NULL,
    ExpirationDate SmallDatetime NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,


    CONSTRAINT FK_InternationalLicenses_Applications
        FOREIGN KEY(ApplicationID)
        REFERENCES Applications(ApplicationID),

    CONSTRAINT FK_InternationalLicenses_Drivers
        FOREIGN KEY(DriverID)
        REFERENCES Drivers(DriverID),

    CONSTRAINT FK_InternationalLicenses_Licenses
        FOREIGN KEY(IssuedUsingLocalLicenseID)
        REFERENCES Licenses(LicenseID),

    CONSTRAINT FK_InternationalLicenses_Users
        FOREIGN KEY(CreatedByUserID)
        REFERENCES Users(UserID)
);