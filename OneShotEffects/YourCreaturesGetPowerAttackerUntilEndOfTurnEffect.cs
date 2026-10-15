using Interfaces;

namespace OneShotEffects;

public sealed class YourCreaturesGetPowerAttackerUntilEndOfTurnEffect
    : OneShotEffect
{
    private readonly int power;
    private readonly IContinuousEffectWithCreaturesAndIntegerFactory factory;

    public YourCreaturesGetPowerAttackerUntilEndOfTurnEffect(
        int power,
        IContinuousEffectWithCreaturesAndIntegerFactory factory) : base()
    {
        this.power = power;
        this.factory = factory;
    }

    public YourCreaturesGetPowerAttackerUntilEndOfTurnEffect(
        YourCreaturesGetPowerAttackerUntilEndOfTurnEffect effect) : base(effect)
    {
        power = effect.power;
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id);
        game.AddContinuousEffects(
            Ability,
            factory.Create(creatures, power));
    }

    public override IOneShotEffect Copy()
    {
        return new YourCreaturesGetPowerAttackerUntilEndOfTurnEffect(this);
    }
}
