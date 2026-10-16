using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM04;

public sealed class WhiskingWhirlwind : Spell
{
    public WhiskingWhirlwind() : base("Whisking Whirlwind", 1,
        Civilization.Light)
    {
        AddSpellAbilities(
            new AtTheEndOfTurnEffect(
                new AtTheEndOfTheTurnDelayedTriggeredAbilityFactory(),
                new UntapAreaOfEffect(
                    new CreatureFilter(),
                    SelectionRange.OwnCards
                )
            )
        );
    }
}
