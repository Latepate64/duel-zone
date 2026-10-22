using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

public sealed class FistsOfForever : Spell
{
    public FistsOfForever() : base("Fists of Forever", 1, Civilization.Fire)
    {
        AddSpellAbilities(
            new FistsOfForeverEffect(
                new WheneverSomethingHappensThisTurnAbilityFactory(),
                new FistsOfForeverAbilityFactory(),
                new UntilEndOfThisTurnDuration()
            ));
    }
}
