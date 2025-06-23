using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class Zaltan : Creature
{
    public Zaltan() : base("Zaltan", 5, 3000, Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(
            Race.CyberVirus, new ZaltanEffect()));
    }
}
