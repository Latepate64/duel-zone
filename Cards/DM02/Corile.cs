using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM02;

public class Corile : Creature
{
    public Corile() : base("Corile", 5, 2000, Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CorileEffect()));
    }
}
