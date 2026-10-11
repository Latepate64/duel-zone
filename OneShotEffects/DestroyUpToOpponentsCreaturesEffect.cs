using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Destroy up to x of your opponent's creatures.
/// </summary>
public sealed class DestroyUpToOpponentsCreaturesEffect : DestroyEffect
{
    private readonly ICardFilter filter;

    public DestroyUpToOpponentsCreaturesEffect(
        int max, ICardFilter filter) : base(0, max, true)
    {
        this.filter = filter;
    }

    public DestroyUpToOpponentsCreaturesEffect(
        DestroyUpToOpponentsCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyUpToOpponentsCreaturesEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
    }
}
