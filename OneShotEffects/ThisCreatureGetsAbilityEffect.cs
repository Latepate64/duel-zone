using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// This creature gets ability until the end of the turn.
/// </summary>
public sealed class ThisCreatureGetsAbilityEffect : OneShotEffect
{
    private readonly IAbility ability;
    private readonly IAbilityAddingContinuousEffectFactory factory;

    public ThisCreatureGetsAbilityEffect(
        IAbilityAddingContinuousEffectFactory factory,
        IAbility ability) : base()
    {
        this.ability = ability;
        this.factory = factory;
    }

    public ThisCreatureGetsAbilityEffect(
        ThisCreatureGetsAbilityEffect effect) : base(effect)
    {
        ability = effect.ability;
        factory = effect.factory;
    }

    public override IOneShotEffect Copy()
    {
        return new ThisCreatureGetsAbilityEffect(this);
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            factory.Create(ability, (ICreature)Source));
    }
}
