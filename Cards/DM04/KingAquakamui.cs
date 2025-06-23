using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;
using ContinuousEffects;

namespace Cards.DM04;

public sealed class KingAquakamui : Creature
{
    public KingAquakamui() : base("King Aquakamui", 7, 5000, Race.Leviathan, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new KingAquakamuiOneShotEffect()));
        AddStaticAbilities(new KingAquakamuiContinuousEffect());
    }
}
