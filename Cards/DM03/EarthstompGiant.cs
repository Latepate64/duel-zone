using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class EarthstompGiant : Creature
{
    public EarthstompGiant() : base("Earthstomp Giant", 5, 8000, Race.Giant, Civilization.Nature)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new EarthstompGiantEffect()));
    }
}
