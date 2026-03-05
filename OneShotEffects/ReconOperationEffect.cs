using Interfaces;

namespace OneShotEffects;

public sealed class ReconOperationEffect : LookEffect
{
    public ReconOperationEffect() : base(0, 3)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ReconOperationEffect();
    }

    public override string ToString()
    {
        return "Look at up to 3 of your opponent's shields.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return GetOpponent(game).ShieldZone.Cards;
    }
}
