using Interfaces;

namespace OneShotEffects;

public sealed class IkazTheSpydroidUntapEffect : UntapAreaOfEffect, ICardAffectable
{
    public IkazTheSpydroidUntapEffect(ICard card) : base()
    {
        Card = card;
    }

    public IkazTheSpydroidUntapEffect(IkazTheSpydroidUntapEffect effect) : base(effect)
    {
        Card = effect.Card;
    }

    public ICard Card { get; }

    public override IOneShotEffect Copy()
    {
        return new IkazTheSpydroidUntapEffect(this);
    }

    public override string ToString()
    {
        return $"Untap {Card} after the battle.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return [Card];
    }
}
