using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class CharmiliaTheEnticer : Creature
{
    public CharmiliaTheEnticer() : base("Charmilia, the Enticer", 4, 3000,
        Race.SnowFaerie, Civilization.Nature)
    {
        AddAbilities(
            new TapAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new CreatureFilter()
        )));
    }
}