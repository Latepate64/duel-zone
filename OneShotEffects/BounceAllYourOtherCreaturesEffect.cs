using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Return all your other creatures from the battle zone to your hand.
/// </summary>
public sealed class BounceAllYourOtherCreaturesEffect : BounceAreaOfEffect
{
    private readonly ICardFilter filter;

    public BounceAllYourOtherCreaturesEffect(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    public BounceAllYourOtherCreaturesEffect(
        BounceAllYourOtherCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new BounceAllYourOtherCreaturesEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetOtherCreaturesControlledByPlayer(
            (ICreature)source!, filter);
    }
}
