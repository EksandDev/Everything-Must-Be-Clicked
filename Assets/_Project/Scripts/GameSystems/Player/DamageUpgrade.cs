using System.Collections.Generic;
using Zenject;

public class DamageUpgrade : IInitializable
{
    private PlayerStats _playerStats;
    private InventoryModel _inventory;
    private CraftingModel _crafting;
    private List<DamageBoostData> _damageBoosts = new();
    private int _baseDamage = 2;

    #region Zenject init
    [Inject]
    private void Initialize(PlayerStats playerStats, InventoryModel inventory, CraftingModel crafting)
    {
        _playerStats = playerStats;
        _inventory = inventory;
        _crafting = crafting;
    }
    #endregion

    public void Initialize() => _crafting.ItemCrafted += StatUp;

    private void StatUp(DamageBoostData data)
    {
        var estimatedDamage = _baseDamage;
        _damageBoosts.Add(data);

        foreach (var boost in _damageBoosts)
            estimatedDamage += boost.DamageBoost;

        _playerStats.Damage = estimatedDamage;
    }
}