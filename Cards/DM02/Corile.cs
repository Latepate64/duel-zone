using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

public sealed class Corile : Creature
{
    public Corile() : base("Corile", 5, 2000, Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CorileEffect()));
    }
}
