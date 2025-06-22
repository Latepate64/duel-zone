using Engine.Abilities;
using Interfaces;

namespace Cards.DM05;

public sealed class GlorySnowEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        if (GetOpponent(game).ManaZone.Size > Controller.ManaZone.Size)
        {
            Controller.PutFromTopOfDeckIntoManaZone(game, 2, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new GlorySnowEffect();
    }

    public override string ToString()
    {
        return "If your opponent has more cards in his mana zone than you have in yours, put the top 2 cards of your deck into your mana zone.";
    }
}
