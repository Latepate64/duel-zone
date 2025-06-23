using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.Promo;

public sealed class StarCryDragon : Creature
{
    public StarCryDragon() : base("Star-Cry Dragon", 7, 8000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(new StarCryDragonEffect());
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
