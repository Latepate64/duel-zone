using TriggeredAbilities;
using Interfaces;

namespace Cards.DM11;

public sealed class BonfireLizard : WaveStrikerCreature
{
    public BonfireLizard() : base("Bonfire Lizard", 6, 4000, Race.MeltWarrior, Civilization.Fire)
    {
        AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BonfireLizardEffect()));
    }
}
