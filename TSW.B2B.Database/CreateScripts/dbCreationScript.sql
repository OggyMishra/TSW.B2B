IF (EXISTS (SELECT name 
FROM master.dbo.sysdatabases 
WHERE ('[' + name + ']' = 'EstimateHistory'
OR name = 'EstimateHistory')))
BEGIN
ALTER database EstimateHistory SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP Database EstimateHistory
END
GO

Create Database EstimateHistory
GO

use [EstimateHistory]
GO

CREATE TABLE [BLCK] ([ID] int NOT NULL Primary Key Identity(100000,1)  
, [DESC] nvarchar(50) NOT NULL
, [REM] nvarchar(255)  
);
GO

CREATE TABLE [GRUP] ([ID] int NOT NULL Primary Key Identity(100000,1)  
, [DESC] nvarchar(50) NOT NULL
, [GRP_ID] int NOT NULL FOREIGN KEY REFERENCES [GRUP] ([ID])
, [NATURE] int  
, [SUBLED] int NOT NULL
, [REM] nvarchar(256) 
);
GO

CREATE TABLE [UNIT] ([ID] int NOT NULL Primary Key Identity(100000,1) 
, [DESC] nvarchar(50) NOT NULL
, [REM] nvarchar(255)  
);
GO

CREATE TABLE [ITEM] ([ID] int NOT NULL Primary Key Identity(100000,1)  
, [CODE] nvarchar(20) 
, [DESC] nvarchar(50) NOT NULL
, [CATG_ID] int NOT NULL
, [MRP] decimal(10,2)
, [RATE] decimal(10,2)
, [DISC] int 
, [REM] nvarchar(255) 
);
GO

CREATE TABLE [MINV] ([ID] int NOT NULL Primary Key Identity(1000000000,1)   
, [DOCNO] int NOT NULL 
, [DOCDT] date NOT NULL
, [ACCT_ID] int NOT NULL
, [REM] nvarchar(255)
, [TOTQTY] decimal(10,3) NOT NULL
, [TOTAMT1] decimal(15,2) NOT NULL
, [TOTAMT2] decimal(15,2) NOT NULL
, [FREIGHT] decimal(15,2) 
, [GTOTAL] decimal(15,2) NOT NULL
);
GO






