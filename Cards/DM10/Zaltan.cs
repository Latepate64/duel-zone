using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM10;

public class Zaltan : Creature
{
    public Zaltan() : base("Zaltan", 5, 3000, Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(
            Race.CyberVirus, new ZaltanEffect()));
    }
}
