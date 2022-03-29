USE [DevicesDB]
GO

INSERT INTO [dbo].[Device]
           ([DeviceTypeID]
           ,[DeviceStatusID]
           ,[Device]
           ,[Temperature])
     VALUES
           (3
           ,1
           ,'Device 1'
           ,10)
GO

INSERT INTO [dbo].[Device]
           ([DeviceTypeID]
           ,[DeviceStatusID]
           ,[Device]
           ,[Temperature])
     VALUES
           (4
           ,2
           ,'Device 2'
           ,25)
GO

INSERT INTO [dbo].[Device]
           ([DeviceTypeID]
           ,[DeviceStatusID]
           ,[Device]
           ,[Temperature])
     VALUES
           (1
           ,1
           ,'Device 3'
           ,40)
GO

INSERT INTO [dbo].[Device]
           ([DeviceTypeID]
           ,[DeviceStatusID]
           ,[Device]
           ,[Temperature])
     VALUES
           (3
           ,1
           ,'Device 4'
           ,15)
GO
