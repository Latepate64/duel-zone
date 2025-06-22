using Engine.Abilities;
using System.Linq;
using Interfaces;

namespace Cards.DM09;

public class TekoraxEffect : OneShotEffect
{
    public TekoraxEffect()
    {
    }

    public TekoraxEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var cards = GetOpponent(game).ShieldZone.Cards.ToArray();
        if (cards.Any())
        {
            Controller.Look(GetOpponent(game), game, cards);
            GetOpponent(game).Unreveal(cards);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new TekoraxEffect(this);
    }

    public override string ToString()
    {
        return "Look at your opponent's shields. Then put them back where they were.";
    }
}
