using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM07;

public class BattleshipMutant : Creature
{
    public BattleshipMutant() : base("Battleship Mutant", 6, 5000, Race.Hedrian, Civilization.Darkness)
    {
        AddAbilities(new TapAbility(new BattleshipMutantEffect()));
    }
}
