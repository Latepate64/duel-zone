using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class ChaosStrikeOneShotEffect : CreatureSelectionEffect
{
    public ChaosStrikeOneShotEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ChaosStrikeOneShotEffect();
    }

    public override string ToString()
    {
        return "Choose one of your opponent's untapped creatures in the battle zone. Your creatures can attack it this turn as though it were tapped.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        if (cards.Length == 1)
        {
            game.AddContinuousEffects(Ability, new ChaosStrikeContinousEffect(cards[0].Id));
        }
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableUntappedCreaturesControlledByPlayer(game, GetOpponent(game).Id);
    }
}
