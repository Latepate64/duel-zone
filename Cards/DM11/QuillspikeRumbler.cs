using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

public sealed class QuillspikeRumbler : Creature
{
    public QuillspikeRumbler() : base("Quillspike Rumbler", 4, 3000,
        Race.BeastFolk, Civilization.Nature)
    {
        AddTriggeredAbility(
            new QuillspikeRumblerAbility(
                new AddCreatureAffectingNumberEffect(
                    3000,
                    new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffectFactory())));
    }
}
