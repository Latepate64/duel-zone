using Engine.Abilities;
using Interfaces;
using System.Linq;

namespace Cards.DM11;

public sealed class MiraculousMeltdownOneShotEffect : OneShotEffect
{
    public MiraculousMeltdownOneShotEffect()
    {
    }

    public MiraculousMeltdownOneShotEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var amount = Controller.ShieldZone.Size;
        var chosen = GetOpponent(game).ChooseCards(GetOpponent(game).ShieldZone.Cards, amount, amount, ToString());
        var toHand = GetOpponent(game).ShieldZone.Cards.Except(chosen);
        game.PutFromShieldZoneToHand(toHand, true, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new MiraculousMeltdownOneShotEffect(this);
    }

    public override string ToString()
    {
        return "Your opponent chooses one of his shields for each shield you have. He puts the rest of his shields into his hand.";
    }
}
