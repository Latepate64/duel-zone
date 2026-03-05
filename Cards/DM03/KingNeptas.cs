using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class KingNeptas : Creature
{
    public KingNeptas() : base("King Neptas", 6, 5000, Race.Leviathan, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new KingNeptasEffect()));
    }
}
