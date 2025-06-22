using Engine.Abilities;
using Interfaces;
using System.Linq;

namespace Cards.DM04;

public class DarkpactEffect : OneShotEffect
{
    public DarkpactEffect()
    {
    }

    public DarkpactEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var cards = player.ChooseAnyNumberOfCards(player.ManaZone.Cards, ToString()).ToArray();
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, cards);
        player.DrawCards(cards.Length, game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new DarkpactEffect(this);
    }

    public override string ToString()
    {
        return "Put any number of cards from your mana zone into your graveyard. Then draw that many cards.";
    }
}
