using Engine.Abilities;
using Interfaces;

namespace Cards.DM04;

public sealed class MegaDetonatorDiscardEffect : OneShotEffect
{
    public MegaDetonatorDiscardEffect()
    {
    }

    public MegaDetonatorDiscardEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var amount = player.DiscardAnyNumberOfCards(game, Ability);
        var creatures = player.ChooseControlledCreatures(game, ToString(), amount);
        game.AddContinuousEffects(Ability, new MegaDetonatorContinuousEffect([.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new MegaDetonatorDiscardEffect(this);
    }

    public override string ToString()
    {
        return "Discard any number of cards from your hand. Then choose the same number of your creatures in the battle zone. Each of those creatures gets \"double breaker\" until the end of the turn.";
    }
}
