using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

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

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
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
