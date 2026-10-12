using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM03;

public sealed class BonePiercer : Creature
{
    public BonePiercer() : base("Bone Piercer", 2, 1000, Race.BrainJacker,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new ManaRecoveryEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    ownMana: true
        )));
    }
}
