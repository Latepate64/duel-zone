using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM01;

public class BolshackDragon : Creature
{
    public BolshackDragon() : base("Bolshack Dragon", 6, 6000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(new BolshackDragonEffect(), new DoubleBreakerEffect());
    }
}
