using ContinuousEffects;
using Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class HeavyweightDragon : Creature
{
    public HeavyweightDragon() : base("Heavyweight Dragon", 7, 9000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddAbilities(new TapAbility(new HeavyweightDragonEffect()));
    }
}
