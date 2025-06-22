using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class KingTsunami : Creature
{
    public KingTsunami() : base("King Tsunami", 12, 12000, Race.Leviathan, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new KingTsunamiEffect()));
        AddStaticAbilities(new TripleBreakerEffect());
    }
}
