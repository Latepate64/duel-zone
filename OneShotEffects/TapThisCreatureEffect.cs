using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class TapThisCreatureEffect : TapAreaOfEffect
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

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return new List<ICard> { Ability.Source }.Where(x => x != null);
    }
}
