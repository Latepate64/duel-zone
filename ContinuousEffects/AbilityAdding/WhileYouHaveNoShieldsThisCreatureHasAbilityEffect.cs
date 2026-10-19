using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class WhileYouHaveNoShieldsThisCreatureHasAbilityEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    private readonly IStaticAbilityFactory abilityFactory;

    public WhileYouHaveNoShieldsThisCreatureHasAbilityEffect(
        IStaticAbilityFactory abilityFactory) : base()
    {
        this.abilityFactory = abilityFactory;
    }

    private WhileYouHaveNoShieldsThisCreatureHasAbilityEffect(
        WhileYouHaveNoShieldsThisCreatureHasAbilityEffect effect) : base(effect)
    {
        abilityFactory = effect.abilityFactory;
    }

    public void AddAbility(IGame game)
    {
        if (!Controller.ShieldZone.HasCards)
        {
            Source.AddGrantedAbility(abilityFactory.Create());
        }
    }

    public override IContinuousEffect Copy()
    {
        return new WhileYouHaveNoShieldsThisCreatureHasAbilityEffect(this);
    }
}
