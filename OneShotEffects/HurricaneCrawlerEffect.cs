using Interfaces;

namespace OneShotEffects;

public sealed class HurricaneCrawlerEffect : OneShotEffect
{
    public HurricaneCrawlerEffect()
    {
    }

    public HurricaneCrawlerEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var hand = Controller.Hand;
        var amount = hand.Size;
        game.Move(Ability, ZoneType.Hand, ZoneType.ManaZone, [.. hand.Cards]);
        var cards = Controller.ChooseCards(Controller.ManaZone.Cards, amount, amount, ToString());
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, [.. cards]);
    }

    public override IOneShotEffect Copy()
    {
        return new HurricaneCrawlerEffect(this);
    }

    public override string ToString()
    {
        return "Put all the cards from your hand into your mana zone. Then put that many cards from your mana zone into your hand.";
    }
}
