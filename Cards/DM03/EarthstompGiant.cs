using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM03;

public class EarthstompGiant : Creature
{
    public EarthstompGiant() : base("Earthstomp Giant", 5, 8000, Race.Giant, Civilization.Nature)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new EarthstompGiantEffect()));
    }
}
