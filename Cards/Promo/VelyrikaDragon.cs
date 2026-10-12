using TriggeredAbilities;
using OneShotEffects;
using Abilities.Static;
using Interfaces;
using CardFilters;

namespace Cards.Promo;

sealed class VelyrikaDragon : Creature
{
    public VelyrikaDragon() : base("Velyrika Dragon", 7, 7000,
        Race.ArmoredDragon, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new RaceCreatureFilter(Race.ArmoredDragon)
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}