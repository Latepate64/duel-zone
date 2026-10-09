using Abilities;
using Abilities.Static;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class HeavyweightDragon : Creature
{
    public HeavyweightDragon() : base("Heavyweight Dragon", 7, 9000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddAbilities(new TapAbility(new HeavyweightDragonEffect()));
    }
}
