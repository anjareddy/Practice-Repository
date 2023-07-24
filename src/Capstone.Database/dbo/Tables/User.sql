CREATE TABLE [dbo].[User] (
    [Id]                           INT           IDENTITY (1, 1) NOT NULL,
    [Name]                         VARCHAR (500) NULL,
    [EmailId]                      VARCHAR (500) NULL,
    [MobileNumber]                 VARCHAR (500) NULL,
    [EmergencyContactName]         VARCHAR (500) NULL,
    [EmergencyContactEmailId]      VARCHAR (500) NULL,
    [EmergencyContactMobileNumber] VARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

