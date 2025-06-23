using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace OneShotEffects;

public sealed class BatDoctorShadowOfUndeathEffect : SalvageEffect
{
    public BatDoctorShadowOfUndeathEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BatDoctorShadowOfUndeathEffect();
    }

    public override string ToString()
    {
        return "You may return another creature from your graveyard to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.GetOtherCreatures(Ability.Source.Id);
    }
}
