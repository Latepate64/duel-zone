using Engine;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public abstract class SearchEffect : SearchAnyDeckEffect
{
    public bool Reveal { get; }

    protected SearchEffect(bool reveal, int maximum = 1) : base(maximum)
    {
        Reveal = reveal;
    }

    protected SearchEffect(SearchEffect effect) : base(effect)
    {
        Reveal = effect.Reveal;
    }

    protected override void Apply(IGame game, IAbility source, params Card[] cards)
    {
        if (Reveal)
        {
            Controller.ShowCardsToOpponent(game, cards);
        }
        game.Move(Ability, ZoneType.Deck, ZoneType.Hand, cards);
        if (Reveal)
        {
            Controller?.Unreveal(cards);
        }
    }
}
