using Engine.Abilities;
using Interfaces;
using System.Linq;

namespace OneShotEffects;

public sealed class UpheavalEffect : OneShotEffect
{
    public UpheavalEffect()
    {
    }

    public UpheavalEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var mana = game.Players.SelectMany(x => x.ManaZone.Cards);
        var hand = game.Players.SelectMany(x => x.Hand.Cards);
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, [.. mana]);
        game.MoveTapped(Ability, ZoneType.Hand, ZoneType.ManaZone, [.. hand]);
    }

    public override IOneShotEffect Copy()
    {
        return new UpheavalEffect(this);
    }

    public override string ToString()
    {
        return "Each player puts all the cards from his mana zone into his hand and, at the same time, puts all the cards from his hand into his mana zone tapped.";
    }
}
