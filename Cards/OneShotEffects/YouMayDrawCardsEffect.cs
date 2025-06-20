using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects;

public abstract class YouMayDrawCardsEffect : OneShotEffect
{
    public int Maximum { get; }

    protected YouMayDrawCardsEffect(int maximum) : base()
    {
        Maximum = maximum;
    }

    protected YouMayDrawCardsEffect(YouMayDrawCardsEffect effect)
    {
        Maximum = effect.Maximum;
    }

    public override void Apply(IGame game)
    {
        Controller.DrawCardsOptionally(game, Ability, Maximum);
    }

    public override string ToString()
    {
        return Maximum == 1 ? "You may draw a card." : $"You may draw up to {Maximum} cards.";
    }
}
