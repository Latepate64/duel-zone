using TriggeredAbilities;
using Interfaces;

namespace Cards.DM12;

public sealed class UncannyTurnip : WaveStrikerCreature
{
    public UncannyTurnip() : base("Uncanny Turnip", 2, 1000, Race.WildVeggies, Civilization.Nature)
    {
        AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new UncannyTurnipEffect()));
    }
}
