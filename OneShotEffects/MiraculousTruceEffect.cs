using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Choose a civilization. Until the start of your next turn, creatures of that
/// civilization can't attack you even if your opponent puts them into the
/// battle zone after you cast this spell.
/// </summary>
public sealed class MiraculousTruceEffect : OneShotEffect
{
    private readonly IContinuousEffectWithCivilizationFactory factory;
    private readonly IDuration duration;

    public MiraculousTruceEffect(
        IContinuousEffectWithCivilizationFactory factory,
        IDuration duration)
    {
        this.factory = factory;
        this.duration = duration;
    }

    public MiraculousTruceEffect(MiraculousTruceEffect effect) : base(effect)
    {
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var civilization = Controller.ChooseCivilization(ToString());
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(civilization));
    }

    public override IOneShotEffect Copy()
    {
        return new MiraculousTruceEffect(this);
    }
}
