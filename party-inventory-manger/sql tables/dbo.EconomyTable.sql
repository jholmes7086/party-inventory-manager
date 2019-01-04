DROP TABLE IF EXISTS dbo.EconomyTable
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id=OBJECT_ID(N'dbo.EconomyTable') AND type in (N'U'))

BEGIN
CREATE TABLE dbo.EconomyTable
(
	Id BIGINT NOT NULL PRIMARY KEY, 
    StandardCurrencyId BIGINT NULL 
)

INSERT INTO dbo.EconomyTable (Id, StandardCurrencyId)
Values (0,0);

END