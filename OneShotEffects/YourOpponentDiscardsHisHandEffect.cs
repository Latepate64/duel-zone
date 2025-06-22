using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class YourOpponentDiscardsHisHandEffect : CardMovingAreaOfEffect
{
    public YourOpponentDiscardsHisHandEffect() : base(ZoneType.Hand, ZoneType.Graveyard)
    {
    }

    public YourOpponentDiscardsHisHandEffect(CardMovingAreaOfEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YourOpponentDiscardsHisHandEffect(this);
    }

    public override string ToString()
    {
        return "Your opponent discards his hand.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return GetOpponent(game).Hand.Cards;
    }
}
