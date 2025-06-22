using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM08;

public sealed class GrapeGlobbo : Creature
{
    public GrapeGlobbo() : base("Grape Globbo", 2, 1000, Race.CyberVirus, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new LookAtYourOpponentsHandEffect()));
    }
}
