using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

public sealed class MiracleQuest : Spell
{
    public MiracleQuest() : base("Miracle Quest", 3, Civilization.Water)
    {
        AddSpellAbilities(
            new WheneverSomethingHappensThisTurnEffect(
                new WheneverSomethingHappensThisTurnAbilityFactory(),
                new WheneverAnyOfYourCreaturesFinishesAttackingAbility(
                    new MiracleQuestDrawEffect())
            ));
    }
}
