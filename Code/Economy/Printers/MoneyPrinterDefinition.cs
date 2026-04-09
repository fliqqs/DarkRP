public sealed class MoneyPrinterDefinition
{
	public MoneyPrinterDefinition(
		MoneyPrinterType type,
		string title,
		int price,
		int moneyPerTick,
		float interval,
		int maxStoredMoney,
		Color tint,
		string description )
	{
		Type = type;
		Title = title;
		Price = price;
		MoneyPerTick = moneyPerTick;
		Interval = interval;
		MaxStoredMoney = maxStoredMoney;
		Tint = tint;
		Description = description;
	}

	public MoneyPrinterType Type { get; }
	public string Title { get; }
	public int Price { get; }
	public int MoneyPerTick { get; }
	public float Interval { get; }
	public int MaxStoredMoney { get; }
	public Color Tint { get; }
	public string Description { get; }
}
