using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Choose one of your opponent's creatures in the battle zone. It gets "this
/// creature attacks if able" until the start of your next turn.
/// </summary>
public sealed class InfernalCommandEffect : OneShotEffect
{
    private readonly IContinuousEffectFactory factory;
    private readonly IDuration duration;

    public InfernalCommandEffect(IContinuousEffectFactory factory, IDuration duration)
    {
        this.factory = factory;
        this.duration = duration;
    }

    public InfernalCommandEffect(InfernalCommandEffect effect) : base(effect)
    {
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseOpponentsCreature(game, ToString());
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(creature));
    }

    public override IOneShotEffect Copy()
    {
        return new InfernalCommandEffect(this);
    }
}
