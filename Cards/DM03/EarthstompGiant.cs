using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM03;

public sealed class EarthstompGiant : Creature
{
    public EarthstompGiant() : base("Earthstomp Giant", 5, 8000, Race.Giant, Civilization.Nature)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new EarthstompGiantEffect()));
    }
}
