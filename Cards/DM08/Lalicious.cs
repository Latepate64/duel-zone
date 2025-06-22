using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM08;

public class Lalicious : Creature
{
    public Lalicious() : base("Lalicious", 6, 4000, Race.SeaHacker, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new LaliciousEffect()));
    }
}
