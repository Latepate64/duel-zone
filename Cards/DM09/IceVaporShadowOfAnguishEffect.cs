using Engine.Abilities;
using Interfaces;

namespace Cards.DM09;

public class IceVaporShadowOfAnguishEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var opponent = GetOpponent(game);
        opponent.DiscardOwnCard(game, Ability);
        opponent.BurnOwnMana(game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new IceVaporShadowOfAnguishEffect();
    }

    public override string ToString()
    {
        return "He chooses and discards a card from his hand, then chooses a card in his mana zone and puts it into his graveyard.";
    }
}
