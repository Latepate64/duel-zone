using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class ZaltanEffect : OneShotEffect
{
    public ZaltanEffect()
    {
    }

    public ZaltanEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var cards = player.ChooseCards(player.Hand.Cards, 0, 2, ToString());
        game.Move(Ability, ZoneType.Hand, ZoneType.Graveyard, [.. cards]);
        var creatures = player.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByAnyone(
            game, GetOpponent(game).Id), cards.Count(), cards.Count(), ToString());
        game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ZaltanEffect(this);
    }

    public override string ToString()
    {
        return "You may discard up to 2 cards from your hand. For each card you discard, choose a creature in the battle zone and return it to its owner's hand.";
    }
}
