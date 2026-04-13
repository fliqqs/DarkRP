public sealed class MiscShopItemDefinition
{
	public MiscShopItemDefinition( string prefabPath, string title, int price, string description, bool hoboOnly = false )
	{
		PrefabPath = prefabPath;
		Title = title;
		Price = price;
		Description = description;
		HoboOnly = hoboOnly;
	}

	public string PrefabPath { get; }
	public string Title { get; }
	public int Price { get; }
	public string Description { get; }
	public bool HoboOnly { get; }
}

public static class MiscShopCatalog
{
	public const string HoboJobDefinitionPath = "jobs/hobo.jobdef";

	static readonly MiscShopItemDefinition[] Items =
	[
		new( TipJar.PrefabPath, "Tip Jar", 150, "Place a jar so other players can donate money to you.", true )
	];

	public static IReadOnlyList<MiscShopItemDefinition> GetAll()
	{
		return Items;
	}

	public static MiscShopItemDefinition Get( string prefabPath )
	{
		if ( string.IsNullOrWhiteSpace( prefabPath ) )
			return null;

		return Items.FirstOrDefault( x => string.Equals( x.PrefabPath, prefabPath, StringComparison.OrdinalIgnoreCase ) );
	}

	public static bool ShouldShowInShop( Player player, MiscShopItemDefinition item )
	{
		if ( item is null )
			return false;

		return !item.HoboOnly || IsHobo( player );
	}

	public static bool CanPlayerBuy( Player player, string prefabPath, out string reason )
	{
		reason = null;

		var item = Get( prefabPath );
		if ( item is null )
		{
			reason = "Unknown item.";
			return false;
		}

		if ( !item.HoboOnly )
			return true;

		if ( player is null )
		{
			reason = "Player unavailable.";
			return false;
		}

		if ( !IsHobo( player ) )
		{
			reason = "Hobo only.";
			return false;
		}

		return true;
	}

	public static bool IsHobo( Player player )
	{
		var job = player?.CurrentJobDefinition;
		if ( job is null )
			return false;

		if ( string.Equals( job.ResourcePath, HoboJobDefinitionPath, StringComparison.OrdinalIgnoreCase ) )
			return true;

		if ( string.Equals( job.Command, "/hobo", StringComparison.OrdinalIgnoreCase ) )
			return true;

		return string.Equals( job.Title, "Hobo", StringComparison.OrdinalIgnoreCase );
	}
}
