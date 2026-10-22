using CardFilters;
using ContinuousEffects.CostModifying;
using Interfaces;

namespace Cards.DM06;

public sealed class CoccoLupia : Creature
{
    public CoccoLupia() : base("Cocco Lupia", 3, 1000, Race.FireBird, Civilization.Fire)
    {
        AddStaticAbilities(
            new YourCardsCostLessEffect(
                filter: new DragonFilter(),
                reduction: 2,
                minimumCost: 2));
    }
}
