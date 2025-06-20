using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects;

public class TapThisCreatureEffect : TapAreaOfEffect
{
    public TapThisCreatureEffect() : base()
    {
    }

    public TapThisCreatureEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new TapThisCreatureEffect(this);
    }

    public override string ToString()
    {
        return "Tap this creature.";
    }

    protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
    {
        return new List<Card> { Ability.Source }.Where(x => x != null);
    }
}
