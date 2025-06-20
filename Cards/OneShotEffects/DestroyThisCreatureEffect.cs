using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects;

public class DestroyThisCreatureEffect : DestroyAreaOfEffect
{
    public DestroyThisCreatureEffect() : base()
    {
    }

    public DestroyThisCreatureEffect(DestroyAreaOfEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyThisCreatureEffect(this);
    }

    public override string ToString()
    {
        return "Destroy this creature.";
    }

    protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
    {
        if (Ability.Source != null)
        {
            return [Ability.Source];
        }
        else
        {
            return [];
        }
    }
}
