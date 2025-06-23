using ContinuousEffects;
using Interfaces;

namespace Cards.DM06;

public sealed class BazookaMutant : Creature
{
    public BazookaMutant() : base("Bazooka Mutant", 4, 8000, Race.Hedrian, Civilization.Darkness)
    {
        AddStaticAbilities(new BazookaMutantEffect());
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}
