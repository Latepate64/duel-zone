using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class PhalEegaDawnGuardian : Creature
{
    public PhalEegaDawnGuardian() : base("Phal Eega, Dawn Guardian", 5, 4000,
        Race.Guardian, Civilization.Light)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new SalvageEffect(
                    minimum: 0,
                    maximum: 1,
                    filter: new SpellFilter(),
                    excludeSource: false
        )));
    }
}