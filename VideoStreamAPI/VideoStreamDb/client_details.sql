CREATE TABLE [dbo].[client_details]
(
	[client_id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [client_name] NCHAR(50) NULL, 
    [client_device] NCHAR(50) NULL

)
