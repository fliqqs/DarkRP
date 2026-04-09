public sealed class WeaponShopItemDefinition
{
	public WeaponShopItemDefinition( string prefabPath, string title, int price, string description )
	{
		PrefabPath = prefabPath;
		Title = title;
		Price = price;
		Description = description;
	}

	public string PrefabPath { get; }
	public string Title { get; }
	public int Price { get; }
	public string Description { get; }
}

public static class WeaponShopCatalog
{
	static readonly WeaponShopItemDefinition[] Items =
	[
		new( "weapons/crowbar/crowbar.prefab", "Crowbar", 250, "A cheap melee option that hits hard at point-blank range." ),
		new( "weapons/glock/glock.prefab", "USP", 600, "A dependable sidearm for cheap, accurate close-range fights." ),
		new( "weapons/colt1911/colt1911.prefab", "1911", 750, "A heavier pistol with stronger shots and a smaller magazine." ),
		new( "weapons/grenade/grenade.prefab", "Grenade", 900, "A thrown explosive for flushing players out of tight positions." ),
		new( "weapons/mp5/mp5.prefab", "SMG", 1600, "A fast-firing SMG built for aggressive short-range pressure." ),
		new( "weapons/shotgun/shotgun.prefab", "Shotgun", 2100, "A close-quarters weapon that deals massive damage up close." ),
		new( "weapons/m4a1/m4a1.prefab", "M4A1", 2600, "A balanced assault rifle that stays effective in most fights." ),
		new( "weapons/sniper/sniper.prefab", "Sniper", 3200, "A high-damage rifle made for long-range picks and hold angles." )
	];

	public static IReadOnlyList<WeaponShopItemDefinition> GetAll()
	{
		return Items;
	}

	public static WeaponShopItemDefinition Get( string prefabPath )
	{
		if ( string.IsNullOrWhiteSpace( prefabPath ) )
			return null;

		return Items.FirstOrDefault( x => string.Equals( x.PrefabPath, prefabPath, StringComparison.OrdinalIgnoreCase ) );
	}
}
