using Interfaces;

namespace OneShotEffects;

public abstract class UntapAreaOfEffect : OneShotAreaOfEffect
{
    protected UntapAreaOfEffect() : base()
    {
    }

    protected UntapAreaOfEffect(UntapAreaOfEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        Controller.Untap(game, [.. GetAffectedCards(game, Ability)]);
    }
}
