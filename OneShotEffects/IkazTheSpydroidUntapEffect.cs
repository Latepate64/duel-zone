using Interfaces;

namespace OneShotEffects;

public sealed class IkazTheSpydroidUntapEffect : UntapAreaOfEffect, ICardAffectable
{
    public IkazTheSpydroidUntapEffect(ICard card) : base()
    {
        Creature = card;
    }

    public IkazTheSpydroidUntapEffect(IkazTheSpydroidUntapEffect effect) : base(effect)
    {
        Creature = effect.Creature;
    }

    public ICard Creature { get; }

    public override IOneShotEffect Copy()
    {
        return new IkazTheSpydroidUntapEffect(this);
    }

    public override string ToString()
    {
        return $"Untap {Creature} after the battle.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return [Creature];
    }
}
