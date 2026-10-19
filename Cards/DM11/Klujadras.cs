using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM11;

public sealed class Klujadras : WaveStrikerCreature
{
    public Klujadras() : base("Klujadras", 7, 4000, Race.SeaHacker,
        Civilization.Water)
    {
        AddWaveStrikerAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new EachPlayersDrawsCardForEachCreatureTheyControlEffect(
                    new WaveStrikerFilter()
                )));
    }
}
