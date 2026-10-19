using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

public sealed class BrutalCharge : Spell
{
    public BrutalCharge() : base("Brutal Charge", 2, Civilization.Nature)
    {
        AddSpellAbilities(
            new AtTheEndOfTurnEffect(
                new AtTheEndOfTheTurnDelayedTriggeredAbilityFactory(),
                new BrutalChargeDelayedEffect()
            ));
    }
}
