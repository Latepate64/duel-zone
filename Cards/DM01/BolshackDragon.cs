using Abilities.Static;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM01;

public sealed class BolshackDragon : Creature
{
    public BolshackDragon() : base("Bolshack Dragon", 6, 6000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(new BolshackDragonEffect());
        AddAbilities(new DoubleBreakerAbility());
    }
}
