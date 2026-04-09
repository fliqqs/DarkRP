using Sandbox.UI;

public sealed partial class Player
{
	[Rpc.Host]
	public void RequestBuyPrinter( MoneyPrinterType type )
	{
		if ( Rpc.Caller != Network.Owner || !MoneyPrinterCatalog.TryGet( type, out var definition ) )
			return;

		if ( MoneyPrinter.CountOwned( Network.Owner ) >= MoneyPrinterCatalog.MaxOwnedPerPlayer )
		{
			Notices.SendNotice( Network.Owner, "block", Color.Red, $"You already own {MoneyPrinterCatalog.MaxOwnedPerPlayer} printers.", 3 );
			return;
		}

		if ( !TryTakeMoney( definition.Price ) )
		{
			Notices.SendNotice( Network.Owner, "block", Color.Red, "You don't have enough money.", 3 );
			return;
		}

		if ( MoneyPrinter.TrySpawn( this, type ) )
		{
			Notices.SendNotice( Network.Owner, "$", Color.Green, $"{definition.Title} purchased.", 3 );
			return;
		}

		GiveMoney( definition.Price );
		Notices.SendNotice( Network.Owner, "block", Color.Red, "Unable to place the printer right now.", 3 );
	}
}
