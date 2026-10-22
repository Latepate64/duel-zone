using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Choose one of your creatures in the battle zone. This turn, it can't be
/// blocked and you ignore any effects that would prevent that creature from
/// attacking your opponent.
/// </summary>
public sealed class MiraclePortalOneShotEffect : OneShotEffect
{
    private readonly IContinuousEffectFactory factory;
    private readonly IDuration duration;

    public MiraclePortalOneShotEffect(IContinuousEffectFactory factory, IDuration duration)
    {
        this.factory = factory;
        this.duration = duration;
    }

    public MiraclePortalOneShotEffect(
        MiraclePortalOneShotEffect effect) : base(effect)
    {
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseControlledCreature(game, ToString());
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
        return new MiraclePortalOneShotEffect(this);
    }
}
