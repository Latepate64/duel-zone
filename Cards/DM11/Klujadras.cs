using TriggeredAbilities;
using Interfaces;

namespace Cards.DM11;

public class Klujadras : WaveStrikerCreature
{
    public Klujadras() : base("Klujadras", 7, 4000, Race.SeaHacker, Civilization.Water)
    {
        AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new KlujadrasEffect()));
    }
}
