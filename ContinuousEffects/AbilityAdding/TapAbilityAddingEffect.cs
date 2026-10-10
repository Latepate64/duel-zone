using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each of your creatures may tap instead of attacking to use this creature's
/// ability.
/// </summary>
public sealed class TapAbilityAddingEffect : AbilityAddingEffect
{
    private readonly ICardFilter filter;

    public TapAbilityAddingEffect(IOneShotEffect effect, ICardFilter filter)
        : base(new TapAbility(effect))
    {
        this.filter = filter;
    }

    public TapAbilityAddingEffect(TapAbilityAddingEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new TapAbilityAddingEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreaturesControllerByPlayer(Applier, filter);
    }
}
