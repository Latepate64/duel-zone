using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class Lalicious : Creature
{
    public Lalicious() : base("Lalicious", 6, 4000, Race.SeaHacker, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new LaliciousEffect()));
    }
}
