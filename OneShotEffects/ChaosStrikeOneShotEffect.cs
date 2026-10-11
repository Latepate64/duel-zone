using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your opponent's creatures in the battle zone. Your creatures
/// can attack it this turn as though it were tapped.
/// </summary>
public sealed class ChaosStrikeOneShotEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;

    public ChaosStrikeOneShotEffect(ICardFilter filter) : base(1, 1, true)
    {
        this.filter = filter;
    }

    public ChaosStrikeOneShotEffect(
        ChaosStrikeOneShotEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ChaosStrikeOneShotEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        if (cards.Length == 1)
        {
            game.AddContinuousEffects(
                Ability, new ChaosStrikeContinousEffect(cards[0].Id));
        }
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
    }
}
