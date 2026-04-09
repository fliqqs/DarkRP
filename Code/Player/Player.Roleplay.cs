public sealed partial class Player
{
	[Property, Sync( SyncFlags.FromHost )]
	public int Money { get; private set; } = 2500;

	[Property, Sync( SyncFlags.FromHost )]
	public string JobTitle { get; private set; } = "Citizen";

	public bool CanAfford( int amount )
	{
		return amount >= 0 && amount <= Money;
	}

	public void GiveMoney( int amount )
	{
		if ( !Networking.IsHost || amount <= 0 )
			return;

		Money += amount;
	}

	public bool TryTakeMoney( int amount )
	{
		if ( !Networking.IsHost || amount < 0 || !CanAfford( amount ) )
			return false;

		Money -= amount;
		return true;
	}

	public void SetMoney( int amount )
	{
		if ( !Networking.IsHost )
			return;

		Money = Math.Max( 0, amount );
	}

	public void SetJobTitle( string title )
	{
		if ( !Networking.IsHost )
			return;

		JobTitle = string.IsNullOrWhiteSpace( title ) ? "Citizen" : title.Trim();
	}
}
