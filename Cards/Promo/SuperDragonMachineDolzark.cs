using ContinuousEffects;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.Promo;

public sealed class SuperDragonMachineDolzark : Creature
{
    public SuperDragonMachineDolzark() : base("Super Dragon Machine Dolzark", 6, 7000,
        [Race.ArmoredDragon, Race.EarthDragon], Civilization.Fire, Civilization.Nature)
    {
        AddTriggeredAbility(new DolzarkAbility(new DolzarkEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
