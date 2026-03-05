using Interfaces;

namespace OneShotEffects;

public sealed class CarnivalTotemEffect : OneShotEffect
{
    public CarnivalTotemEffect()
    {
    }

    public CarnivalTotemEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var mana = Controller.ManaZone.Cards;
        var hand = Controller.Hand.Cards;
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, [.. mana]);
        game.MoveTapped(Ability, ZoneType.Hand, ZoneType.ManaZone, [.. hand]);
    }

    public override IOneShotEffect Copy()
    {
        return new CarnivalTotemEffect(this);
    }

    public override string ToString()
    {
        return "Put all the cards from your mana zone into your hand and, at the same time, put all the cards from your hand into your mana zone tapped.";
    }
}
