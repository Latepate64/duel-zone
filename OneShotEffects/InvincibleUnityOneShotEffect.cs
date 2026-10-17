using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Each of your creatures in the battle zone gets +8000 power and "triple
/// breaker" until the end of the turn.
/// </summary>
public sealed class InvincibleUnityOneShotEffect : OneShotEffect
{
    private readonly IContinuousEffectFactory factory;
    private readonly ICardFilter filter;

    public InvincibleUnityOneShotEffect(
        IContinuousEffectFactory factory, ICardFilter filter)
    {
        this.factory = factory;
        this.filter = filter;
    }

    public InvincibleUnityOneShotEffect(
        InvincibleUnityOneShotEffect effect) : base(effect)
    {
        factory = effect.factory;
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            factory.Create(
                [.. game.BattleZone.GetCreaturesControlledByPlayer(
                    Applier,
                    filter)]));
    }

    public override IOneShotEffect Copy()
    {
        return new InvincibleUnityOneShotEffect(this);
    }
}
