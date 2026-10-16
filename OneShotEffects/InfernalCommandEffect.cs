using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your opponent's creatures in the battle zone. It gets "this
/// creature attacks if able" until the start of your next turn.
/// </summary>
public sealed class InfernalCommandEffect : OneShotEffect
{
    private readonly IContinuousEffectFactory factory;

    public InfernalCommandEffect(IContinuousEffectFactory factory)
    {
        this.factory = factory;
    }

    public InfernalCommandEffect(InfernalCommandEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseOpponentsCreature(game, ToString());
        game.AddContinuousEffects(
            Ability,
            factory.Create(creature));
    }

    public override IOneShotEffect Copy()
    {
        return new InfernalCommandEffect(this);
    }
}
