using OneShotEffects;
using Abilities;
using Interfaces;
using CardFilters;

namespace Cards.DM07;

sealed class TangleFistTheWeaver : Creature
{
    public TangleFistTheWeaver() : base("Tangle Fist, the Weaver", 4, 2000,
        Race.BeastFolk, Civilization.Nature)
    {
        AddAbilities(
            new TapAbility(
                new YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(
                    minimum: 0,
                    maximum: 3,
                    filter: new AnyCardFilter()
        )));
    }
}