using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class AdomisTheOracleEffect : CardSelectionEffect<ICard>
{
    public AdomisTheOracleEffect() : base(1, 1, true)
    {
    }

    public AdomisTheOracleEffect(AdomisTheOracleEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new AdomisTheOracleEffect();
    }

    public override string ToString()
    {
        return "Choose a shield and look at it. Then put it back where it was.";
    }

    protected override void Apply(IGame game, IAbility source, params ICard[] cards)
    {
        Controller.Look(GetOpponent(game), game, cards);
        GetOpponent(game).Unreveal(cards);
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return game.Players.SelectMany(x => x.ShieldZone.Cards);
    }
}
