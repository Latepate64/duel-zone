using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Choose one of your opponent's creatures in the battle zone and tap it. Then
/// you may choose one of your creatures in the battle zone. If you do, it can't
/// be blocked this turn.
/// </summary>
public sealed class LaserWhipEffect : OneShotEffect
{
    private readonly IContinuousEffectFactory factory;
    private readonly IDuration duration;

    public LaserWhipEffect(IContinuousEffectFactory factory, IDuration duration)
    {
        this.factory = factory;
        this.duration = duration;
    }

    public LaserWhipEffect(LaserWhipEffect effect) : base(effect)
    {
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var controller = Controller;
        controller.TapOpponentsCreature(game);
        var creature = controller.ChooseControlledCreatureOptionally(
            game, ToString());
        if (creature != null)
        {
            game.AddContinuousEffects(
                Ability,
                duration,
                factory.Create(creature));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new LaserWhipEffect(this);
    }
}
