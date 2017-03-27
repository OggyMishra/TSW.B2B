Create Database EstimateHistory;
GO

use [EstimateHistory]
Go

CREATE TABLE [BLCK] ([ID] int NOT NULL Primary Key  
, [DESC] nvarchar(50) NOT NULL
, [REM] nvarchar(255)  
);
GO

CREATE TABLE [GRUP] ([ID] int NOT NULL Primary Key  
, [DESC] nvarchar(50) NOT NULL
, [GRP_ID] nvarchar(255) NOT NULL
, [NATURE] int  
, [SUBLED] int NOT NULL
, [REM] nvarchar(256) 
);
GO

CREATE TABLE [UNIT] ([ID] int NOT NULL Primary Key  
, [DESC] nvarchar(50) NOT NULL
, [REM] nvarchar(255)  
);
GO

CREATE TABLE [ITEM] ([ID] int NOT NULL	 Primary Key  
, [CODE] nvarchar(20) 
, [DESC] nvarchar(50) NOT NULL
, [CATG_ID] int NOT NULL
, [MRP] amount
, [RATE] amount
, [DISC] int 
, [REM] nvarchar(255) 
);
GO

CREATE TABLE [MINV] ([ID] int NOT NULL Primary Key  
, [DOCNO] int NOT NULL
, [DOCDT] date NOT NULL
, [ACCT_ID] int NOT NULL
, [REM] nvarchar(255)
, [TOTQTY] quantity NOT NULL
, [TOTAMT1] amount NOT NULL
, [TOTAMT2] amount NOT NULL
, [FREIGHT] amount 
, [GTOTAL] amount NOT NULL
);
GO






