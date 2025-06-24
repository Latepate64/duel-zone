using Interfaces;

namespace OneShotEffects;

public sealed class ApocalypseViseEffect : OneShotEffect
{
    public ApocalypseViseEffect()
    {
    }

    public ApocalypseViseEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.Destroy(Ability, [.. Controller.ChooseAnyNumberOfOpponentsCreatureThatHaveTotalMaxPower(game)]);
    }

    public override IOneShotEffect Copy()
    {
        return new ApocalypseViseEffect(this);
    }

    public override string ToString()
    {
        return "Destroy any number of your opponent's creatures that have total power 8000 or less.";
    }
}
