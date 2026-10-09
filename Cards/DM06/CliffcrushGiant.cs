using Abilities.Static;
using ContinuousEffects.CannotAttack;
using Interfaces;

namespace Cards.DM06;

public sealed class CliffcrushGiant : Creature
{
    public CliffcrushGiant() : base("Cliffcrush Giant", 5, 7000, Race.Giant, Civilization.Nature)
    {
        AddStaticAbilities(new CliffcrushGiantEffect());
        AddAbilities(new DoubleBreakerAbility());
    }
}
