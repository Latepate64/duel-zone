using Interfaces;

namespace OneShotEffects;

public sealed class DestroyAllCreaturesEffect : DestroyAreaOfEffect
{
    public DestroyAllCreaturesEffect() : base()
    {
    }

    public DestroyAllCreaturesEffect(DestroyAreaOfEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyAllCreaturesEffect(this);
    }

    public override string ToString()
    {
        return "Destroy all creatures.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.Creatures;
    }
}
