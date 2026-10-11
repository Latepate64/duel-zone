using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM11;

public sealed class BonfireLizard : WaveStrikerCreature
{
    public BonfireLizard() : base("Bonfire Lizard", 6, 4000, Race.MeltWarrior,
        Civilization.Fire)
    {
        AddWaveStrikerAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyEffect(
                    minimum: 0,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new BlockerFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}
