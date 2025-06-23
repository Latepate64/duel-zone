using TriggeredAbilities;
using Interfaces;

namespace OneShotEffects;

public sealed class MiracleQuestEffect : OneShotEffect
{
    public MiracleQuestEffect()
    {
    }

    public MiracleQuestEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(new WheneverSomethingHappensThisTurnAbility(
            new WheneverAnyOfYourCreaturesFinishesAttackingAbility(new MiracleQuestDrawEffect()), Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new MiracleQuestEffect(this);
    }

    public override string ToString()
    {
        return "Whenever any of your creatures finishes attacking this turn, you may draw 2 cards for each shield it broke.";
    }
}
