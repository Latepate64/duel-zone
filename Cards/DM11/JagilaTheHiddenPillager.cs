using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

public sealed class JagilaTheHiddenPillager : WaveStrikerCreature
{
    public JagilaTheHiddenPillager() : base(
        "Jagila, the Hidden Pillager", 5, 3000, Race.PandorasBox, Civilization.Darkness)
    {
        AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect(3)));
    }
}
