using Abilities;
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
                    new BattleshipMutantContinuousEffect(4000, filter),
                    filter,
                    new WheneverSomethingHappensThisTurnAbilityFactory(),
                    new BattleshipMutantAbilityFactory())
        ));
    }
}
