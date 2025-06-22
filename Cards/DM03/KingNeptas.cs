using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM03;

public class KingNeptas : Creature
{
    public KingNeptas() : base("King Neptas", 6, 5000, Race.Leviathan, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new KingNeptasEffect()));
    }
}
