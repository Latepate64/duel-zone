using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

public sealed class SlashAndBurn : Spell
{
    public SlashAndBurn() : base("Slash and Burn", 4, Civilization.Darkness,
        Civilization.Fire)
    {
        AddSpellAbilities(
            new WheneverSomethingHappensThisTurnEffect(
                new WheneverSomethingHappensThisTurnAbilityFactory(),
                new SlashAndBurnAbility()
            )
        );
    }
}
