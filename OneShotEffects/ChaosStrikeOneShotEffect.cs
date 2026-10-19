using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Choose one of your opponent's creatures in the battle zone. Your creatures
/// can attack it this turn as though it were tapped.
/// </summary>
public sealed class ChaosStrikeOneShotEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;
    private readonly IContinuousEffectFactory factory;
    private readonly IDuration duration;

    public ChaosStrikeOneShotEffect(
        ICardFilter filter, IContinuousEffectFactory factory, IDuration duration) : base(1, 1, true)
    {
        this.filter = filter;
        this.factory = factory;
        this.duration = duration;
    }

    public ChaosStrikeOneShotEffect(
        ChaosStrikeOneShotEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ChaosStrikeOneShotEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
    }
}
