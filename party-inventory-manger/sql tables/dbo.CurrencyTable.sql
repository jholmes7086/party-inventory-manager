DROP TABLE IF EXISTS dbo.CurrencyTable;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id=OBJECT_ID(N'dbo.CurrencyTable') AND type IN (N'U'))

BEGIN

CREATE TABLE dbo.CurrencyTable
(
	EconomyId BIGINT NOT NULL,
	Id BIGINT NOT NULL, 
    Name CHAR(255) NULL, 
    ConversionRateToStandard FLOAT NULL,
	Color CHAR(255) NULL,
	PRIMARY KEY (EconomyId, Id)
);

INSERT INTO dbo.CurrencyTable (EconomyId, Id, Name, ConversionRateToStandard, Color)
VALUES (0, 0, 'Gold', 1, '#ffe699'),
		(0, 1, 'Silver', 0.1, '#e6e6e6'),
		(0, 2, 'Copper', 0.01, '#ffd670'),
		(0, 3, 'Platinum', 10, '#fff2ff');

END
