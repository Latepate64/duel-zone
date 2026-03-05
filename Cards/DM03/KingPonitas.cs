using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class KingPonitas : Creature
{
    public KingPonitas() : base("King Ponitas", 8, 4000, Race.Leviathan, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new KingPonitasEffect()));
    }
}
