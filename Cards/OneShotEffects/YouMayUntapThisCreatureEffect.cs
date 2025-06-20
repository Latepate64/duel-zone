using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects;

public class YouMayUntapThisCreatureEffect : ControllerMayUntapCreatureEffect
{
    public YouMayUntapThisCreatureEffect() : base()
    {
    }

    public YouMayUntapThisCreatureEffect(ControllerMayUntapCreatureEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayUntapThisCreatureEffect(this);
    }

    public override string ToString()
    {
        return "You may untap this creature.";
    }

    protected override IEnumerable<Card> GetSelectableCards(IGame game, IAbility source)
    {
        return new Card[] { Ability.Source };
    }
}
