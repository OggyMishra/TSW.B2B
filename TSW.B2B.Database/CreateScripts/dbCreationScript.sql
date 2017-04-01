DECLARE @dbname nvarchar(128)
SET @dbname = 'EstimateHistory'
IF (EXISTS (SELECT name 
FROM master.dbo.sysdatabases 
WHERE ('[' + name + ']' = @dbname
OR name = @dbname)))
BEGIN
ALTER database EstimateHistory SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP Database EstimateHistory
END
GO

Create Database EstimateHistory
GO

use [EstimateHistory]
GO

CREATE TABLE [dbo].[BLCK] ([ID] int NOT NULL IDENTITY(100000,1)
, [DESC] nvarchar(50) NOT NULL
, [REM] nvarchar(255)
, CONSTRAINT PK_Block PRIMARY KEY NONCLUSTERED ([ID]) 
);
GO

CREATE TABLE [dbo].[CATG] ([ID] int NOT NULL IDENTITY(100000,1)
, [CODE] nvarchar(20)
, [DESC] nvarchar(50) NOT NULL
, [REM] nvarchar(255)
, CONSTRAINT PK_CATG PRIMARY KEY NONCLUSTERED ([ID]) 
);
GO

CREATE TABLE [dbo].[GRUP] ([ID] int NOT NULL IDENTITY(100000,1)  
, [DESC] nvarchar(50) NOT NULL
, [NATURE] int  
, [SUBLED] int NOT NULL
, [REM] nvarchar(256) 
, CONSTRAINT PK_GRUP PRIMARY KEY NONCLUSTERED ([ID])
);
GO

CREATE TABLE [dbo].[UNIT] ([ID] int NOT NULL Identity(100000,1) 
, [DESC] nvarchar(50) NOT NULL
, [REM] nvarchar(255)  
, CONSTRAINT PK_UNIT PRIMARY KEY NONCLUSTERED ([ID])
);
GO

CREATE TABLE [dbo].[ITEM] ([ID] int NOT NULL Identity(100000,1)  
, [CODE] nvarchar(20) 
, [DESC] nvarchar(50) NOT NULL
, [CATG_ID] int NOT NULL
, [MRP] decimal(10,2)
, [RATE] decimal(10,2)
, [DISC] int 
, [REM] nvarchar(255) 
, CONSTRAINT PK_ITEM PRIMARY KEY NONCLUSTERED ([ID])
, CONSTRAINT FK_ITEM_CATG FOREIGN KEY ([CATG_ID]) REFERENCES [dbo].[CATG] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE [dbo].[ACCOUNT] ([ID] int NOT NULL Identity(100000,1)  
, [CODE] nvarchar(20) 
, [DESC] nvarchar(50) NOT NULL
, [ADDRESS] nvarchar(255) 
, [CITY] nvarchar(50) NOT NULL
, [PHS] nvarchar(50) 
, [FAX] nvarchar(50)
, [MOBILE] int 
, [EMAIL] nvarchar(50)
, [TAXNO] nvarchar(20)
, [PAN] nvarchar(20)
, [GRP_ID] int NOT NULL
, [OBAL] decimal(15,2)
, [DRCR] as CASE WHEN ([OBAL] > 0) THEN 1 ELSE 2 END
, [REM] nvarchar(255) 
, CONSTRAINT PK_ACCOUNT PRIMARY KEY NONCLUSTERED ([ID])
, CONSTRAINT FK_ACCOUNT_GRUP FOREIGN KEY ([GRP_ID]) REFERENCES [dbo].[GRUP] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE [dbo].[TRAN] ([ID] int NOT NULL IDENTITY(1000000000,1)
, [VRTY] INT NOT NULL 
, [VRSR] INT NOT NULL
, [VRNO] INT NOT NULL
, [SNO] INT
, [DT] DATE NOT NULL
, [BLCK_ID] INT NOT NULL -- BLOCK_ID
, [ACCT_ID] INT NOT NULL -- ACCOUNT_ID
, [DRAMT] DECIMAL(15,2) NOT NULL
, [CRAMT] DECIMAL(15,2) NOT NULL
, [DRCR] INT NOT NULL
, [NARR] nvarchar(255)
, [REF] nvarchar(50)
, [REFDT] DATE
, [CUSER_ID] INT NOT NULL -- CREATED BY USERID
, [CDTTM] DATETIME NOT NULL
, [MUSER_ID] INT 
, [MDTTM] DATETIME
, CONSTRAINT PK_TRAN PRIMARY KEY NONCLUSTERED ([ID]) 
, CONSTRAINT SNO_RESTRICT CHECK ([SNO] > 100)
, CONSTRAINT DRCR_RESTRICT CHECK ([DRCR] = 1 OR [DRCR] = 2)
, CONSTRAINT VRTY_RESTRICT CHECK ([VRTY] = 2 OR [VRTY] = 3)
, CONSTRAINT VRSR_RESTRICT CHECK ([VRSR] = 2 OR [VRSR] = 3)
, CONSTRAINT FK_Tran_Blck FOREIGN KEY ([BLCK_ID]) REFERENCES [dbo].[BLCK] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
, CONSTRAINT FK_Tran_Account FOREIGN KEY ([ACCT_ID]) REFERENCES [dbo].[ACCOUNT] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE [dbo].[MINV] ([ID] int NOT NULL Identity(1000000000,1)   
, [DOCNO] int NOT NULL 
, [DOCDT] date NOT NULL
, [ACCT_ID] int NOT NULL
, [REM] nvarchar(255)
, [TOTQTY] decimal(10,3) NOT NULL
, [TOTAMT1] decimal(15,2) NOT NULL
, [TOTAMT2] decimal(15,2) NOT NULL
, [FREIGHT] decimal(15,2) 
, [GTOTAL] decimal(15,2) NOT NULL
, CONSTRAINT PK_MINV PRIMARY KEY NONCLUSTERED ([ID])
, CONSTRAINT FK_MINV_ACCOUNT FOREIGN KEY ([ACCT_ID]) REFERENCES [dbo].[ACCOUNT] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE [dbo].[SINV] ([ID] int NOT NULL Identity(1000000000,1)
, [MINVID] int NOT NULL
, [SNO] int NOT NULL
, [ITEM_ID] int NOT NULL 
, [QTY] decimal(10,3) NOT NULL
, [RATE] decimal(15,2) NOT NULL
, [AMT1] decimal(15,2) NOT NULL
, [DISC_P] int 
, [AMT2] decimal(15,2) NOT NULL
, [ADDTXT1] nvarchar(255)
, [ADDTXT2] nvarchar(255) 
, CONSTRAINT PK_SINV PRIMARY KEY NONCLUSTERED ([ID])
, CONSTRAINT FK_SINV_MINV FOREIGN KEY ([MINVID]) REFERENCES [dbo].[MINV] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- master data 
INSERT INTO dbo.BLCK
(
    --ID - this column value is auto-generated
    [DESC],
    REM
)
VALUES
(
    -- ID - int
    'cde', -- DESC - nvarchar
    'cde' -- REM - nvarchar
)

INSERT INTO dbo.CATG
(
    --ID - this column value is auto-generated
    CODE,
    [DESC],
    REM
)
VALUES
(
    -- ID - int
    'ref', -- CODE - nvarchar
    'abc', -- DESC - nvarchar
    'ref' -- REM - nvarchar
)

INSERT INTO dbo.UNIT
(
    --ID - this column value is auto-generated
    [DESC],
    REM
)
VALUES
(
    -- ID - int
    'abc', -- DESC - nvarchar
    'epr' -- REM - nvarchar
)

INSERT INTO dbo.GRUP
(
    --ID - this column value is auto-generated
    [DESC],
    NATURE,
    SUBLED,
    REM
)
VALUES
(
    -- ID - int
    'abcd', -- DESC - nvarchar
    12, -- NATURE - int
    123, -- SUBLED - int
    'abc' -- REM - nvarchar
)

INSERT INTO dbo.ITEM
(
    --ID - this column value is auto-generated
    CODE,
    [DESC],
    CATG_ID,
    MRP,
    RATE,
    DISC,
    REM
)
VALUES
(
    -- ID - int
    'abc', -- CODE - nvarchar
    'cde', -- DESC - nvarchar
    100000, -- CATG_ID - int
    1344, -- MRP - decimal
    0, -- RATE - decimal
    0, -- DISC - int
    'rdm' -- REM - nvarchar
)

INSERT INTO dbo.ACCOUNT
(
    --ID - this column value is auto-generated
    CODE,
    [DESC],
    ADDRESS,
    CITY,
    PHS,
    FAX,
    MOBILE,
    EMAIL,
    TAXNO,
    PAN,
    GRP_ID,
    OBAL,
    REM
)
VALUES
(
    -- ID - int
    'abc', -- CODE - nvarchar
    'cdf', -- DESC - nvarchar
    'askjhfkja', -- ADDRESS - nvarchar
    'delhi', -- CITY - nvarchar
    'rddd', -- PHS - nvarchar
    'jkjkasf', -- FAX - nvarchar
    98182239, -- MOBILE - int
    'kfasfkaksjkl;', -- EMAIL - nvarchar
    'khajskdfhkaskf', -- TAXNO - nvarchar
    '23232', -- PAN - nvarchar
    100000, -- GRP_ID - int
    1000, -- OBAL - decimal
    'fdakssk' -- REM - nvarchar
)



















