using Abilities.Static;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.Promo;

public sealed class StarCryDragon : Creature
{
    public StarCryDragon() : base("Star-Cry Dragon", 7, 8000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(new StarCryDragonEffect());
        AddAbilities(new DoubleBreakerAbility());
    }
}
