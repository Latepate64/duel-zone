using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class BattleshipMutant : Creature
{
    public BattleshipMutant() : base("Battleship Mutant", 6, 5000, Race.Hedrian,
        Civilization.Darkness)
    {
        AddAbilities(new TapAbility(new BattleshipMutantEffect(
            4000,
            new CivilizationCreatureFilter(Civilization.Darkness))));
    }
}
