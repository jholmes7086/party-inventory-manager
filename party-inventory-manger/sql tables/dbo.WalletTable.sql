DROP TABLE IF EXISTS dbo.WalletTable;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id=OBJECT_ID(N'dbo.WalletTable') AND type IN (N'U'))

BEGIN

CREATE TABLE dbo.WalletTable
(
	Id BIGINT NOT NULL PRIMARY KEY, 
    EconomyId BIGINT NOT NULL
);

INSERT INTO dbo.WalletTable (Id, EconomyId)
VALUES (0,0);

END
