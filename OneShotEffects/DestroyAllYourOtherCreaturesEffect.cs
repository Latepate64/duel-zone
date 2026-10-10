using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Destroy all your other creatures.
/// </summary>
public sealed class DestroyAllYourOtherCreaturesEffect : DestroyAreaOfEffect
{
    private readonly ICardFilter filter;

    public DestroyAllYourOtherCreaturesEffect(ICardFilter filter) : base()
    {
        this.filter = filter;
    }

    public DestroyAllYourOtherCreaturesEffect(
        DestroyAllYourOtherCreaturesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyAllYourOtherCreaturesEffect(this);
    }


    protected override IEnumerable<ICard> GetAffectedCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetOtherCreaturesControlledByPlayer(
            (ICreature)Source, filter);
    }
}
