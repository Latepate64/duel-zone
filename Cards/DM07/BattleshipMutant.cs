using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

public sealed class BattleshipMutant : Creature
{
    public BattleshipMutant() : base("Battleship Mutant", 6, 5000, Race.Hedrian,
        Civilization.Darkness)
    {
        AddAbilities(
            new TapAbility(
                new BattleshipMutantEffect(
                    power: 4000,
                    filter: new CivilizationCreatureFilter(
                        Civilization.Darkness),
                    new WheneverSomethingHappensThisTurnAbilityFactory(),
                    new BattleshipMutantAbilityFactory()
        )));
    }
}
