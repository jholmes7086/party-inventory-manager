DROP TABLE IF EXISTS dbo.CurrencyCountTable;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id=OBJECT_ID(N'dbo.CurrencyCountTable') AND type IN (N'U'))

BEGIN
CREATE TABLE dbo.CurrencyCountTable
(
	Id BIGINT NOT NULL PRIMARY KEY, 
    WalletId BIGINT NOT NULL, 
    CurrencyId BIGINT NOT NULL, 
    Quantity INT NULL
)

INSERT INTO dbo.CurrencyCountTable (Id, WalletId, CurrencyId, Quantity)
VALUES (0,0,0,0),
		(1,0,1,0),
		(2,0,2,0),
		(3,0,3,0);

End