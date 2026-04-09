public static class MoneyPrinterCatalog
{
	public const int MaxOwnedPerPlayer = 5;

	static readonly MoneyPrinterDefinition[] Definitions =
	[
		new MoneyPrinterDefinition(
			MoneyPrinterType.Bronze,
			"Bronze Printer",
			500,
			25,
			20.0f,
			8000,
			new Color( 0.33725f, 0.07843f, 0.0f ),
			"Entry-level printer that generates $25 every 20 seconds."
		),
		new MoneyPrinterDefinition(
			MoneyPrinterType.Silver,
			"Silver Printer",
			1200,
			25,
			15.0f,
			8000,
			new Color( 0.94902f, 0.94118f, 0.93725f ),
			"Balanced printer that generates $25 every 15 seconds."
		),
		new MoneyPrinterDefinition(
			MoneyPrinterType.Gold,
			"Gold Printer",
			2600,
			25,
			10.0f,
			8000,
			new Color( 1.0f, 0.78333f, 0.0f ),
			"High-tier printer that generates $25 every 10 seconds."
		),
		new MoneyPrinterDefinition(
			MoneyPrinterType.Diamond,
			"Diamond Printer",
			4800,
			25,
			5.0f,
			8000,
			new Color( 0.0f, 0.85098f, 1.0f ),
			"Top-tier printer that generates $25 every 5 seconds."
		)
	];

	static readonly IReadOnlyDictionary<MoneyPrinterType, MoneyPrinterDefinition> ByType
		= Definitions.ToDictionary( x => x.Type );

	public static IReadOnlyList<MoneyPrinterDefinition> All => Definitions;

	public static bool TryGet( MoneyPrinterType type, out MoneyPrinterDefinition definition )
	{
		return ByType.TryGetValue( type, out definition );
	}

	public static MoneyPrinterDefinition Get( MoneyPrinterType type )
	{
		return ByType[type];
	}
}
