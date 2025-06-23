using Interfaces;

namespace OneShotEffects;

public sealed class FunkyWizardEffect : OneShotEffect
{
    public FunkyWizardEffect()
    {
    }

    public FunkyWizardEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        foreach (var player in game.Players)
        {
            if (player.ChooseToTakeAction("You may draw a card."))
            {
                player.DrawCards(1, game, Ability);
            }
        }
    }

    public override IOneShotEffect Copy()
    {
        return new FunkyWizardEffect(this);
    }

    public override string ToString()
    {
        return "Each player may draw a card.";
    }
}
