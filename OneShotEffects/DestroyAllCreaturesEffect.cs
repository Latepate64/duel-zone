using Interfaces;

namespace OneShotEffects;

public sealed class DestroyAllCreaturesEffect : DestroyAreaOfEffect
{
    private readonly ICardFilter filter;

    public DestroyAllCreaturesEffect(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    public DestroyAllCreaturesEffect(DestroyAllCreaturesEffect effect) : base(
        effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyAllCreaturesEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(filter);
    }
}
