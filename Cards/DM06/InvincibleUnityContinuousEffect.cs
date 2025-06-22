using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.DM06;

public class InvincibleUnityContinuousEffect : UntilEndOfTurnEffect, IAbilityAddingEffect, IPowerModifyingEffect
{
    private readonly List<ICreature> _cards;

    public InvincibleUnityContinuousEffect(IEnumerable<ICreature> cards)
    {
        _cards = [.. cards];
    }

    public InvincibleUnityContinuousEffect(InvincibleUnityContinuousEffect effect) : base(effect)
    {
        _cards = effect._cards;
    }

    public void AddAbility(IGame game)
    {
        _cards.ForEach(x => x.AddGrantedAbility(new StaticAbility(new TripleBreakerEffect())));
    }

    public override IContinuousEffect Copy()
    {
        return new InvincibleUnityContinuousEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        _cards.ForEach(x => x.IncreasePower(8000));
    }

    public override string ToString()
    {
        return $"{_cards} get +8000 power and \"triple breaker\" until the end of the turn.";
    }
}
