using Abilities;
using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

public sealed class BattleshipMutant : Creature
{
    public BattleshipMutant() : base("Battleship Mutant", 6, 5000, Race.Hedrian,
        Civilization.Darkness)
    {
        var filter = new CivilizationCreatureFilter(Civilization.Darkness);
        AddAbilities(
            new TapAbility(
                new BattleshipMutantEffect(
                    new EachOfYourCreaturesGetsPowerAndAbilitiesEffect(
                        filter,
                        4000,
                        new DoubleBreakerAbility()
                    ),
                    filter,
                    new WheneverSomethingHappensThisTurnAbilityFactory(),
                    new BattleshipMutantAbilityFactory())
        ));
    }
}
