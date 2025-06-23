using OneShotEffects;
using Engine.Abilities;
using Interfaces;
using Engine.Choices;

namespace OneShotEffects;

public sealed class ClonedNightmareEffect : ClonedEffect
{
    public ClonedNightmareEffect(string name) : base(name)
    {
    }

    public ClonedNightmareEffect(ClonedNightmareEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var number = GetAmount(game);
        if (number > 1)
        {
            number = Controller.ChooseNumber(new ClonedNightmareChoice(
                Controller, "Choose how many cards your opponent will discard at random from their hand.", number));
        }
        GetOpponent(game).DiscardAtRandom(game, number, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new ClonedNightmareEffect(this);
    }

    public override string ToString()
    {
        return $"Choose a card at random from opponent's hand. Then, for each {_name} in each graveyard, you may choose another card at random from opponent's hand. Your opponent discards all those cards.";
    }
}
