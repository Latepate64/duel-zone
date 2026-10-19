using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureHasAbilityWhileYourManaCardsAreCivilizationEffect
    : ContinuousEffect, IAbilityAddingEffect
{
    private readonly Civilization civilization;
    private readonly IAbility ability;

    public ThisCreatureHasAbilityWhileYourManaCardsAreCivilizationEffect(
        Civilization civilization,
        IAbility ability) : base()
    {
        this.civilization = civilization;
        this.ability = ability;
    }

    private ThisCreatureHasAbilityWhileYourManaCardsAreCivilizationEffect(
        ThisCreatureHasAbilityWhileYourManaCardsAreCivilizationEffect effect) : base(effect)
    {
        civilization = effect.civilization;
        ability = effect.ability.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureHasAbilityWhileYourManaCardsAreCivilizationEffect(this);
    }

    public void AddAbility(IGame game)
    {
        if (Source!.OwnerV2.ManaZone.AreAllCivilizationCards(civilization))
        {
            game.AddAbility(Source, ability);
        }
    }
}
