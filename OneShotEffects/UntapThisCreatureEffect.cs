using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public class UntapThisCreatureEffect : UntapAreaOfEffect
{
    public UntapThisCreatureEffect() : base() { }

    public UntapThisCreatureEffect(UntapAreaOfEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new UntapThisCreatureEffect(this);
    }

    public override string ToString()
    {
        return "Untap this creature.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return new List<ICard> { Ability.Source }.Where(x => x != null);
    }
}
