using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose up to 2 of your creatures in the battle zone. At the end of the turn,
/// you may untap them.
/// </summary>
public sealed class LunarChargerEffect : OneShotEffect
{
    private readonly IDelayedTriggeredAbilityWithTurnAndCreaturesFactory factory;

    public LunarChargerEffect(IDelayedTriggeredAbilityWithTurnAndCreaturesFactory factory)
    {
        this.factory = factory;
    }

    public LunarChargerEffect(LunarChargerEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        var creatures = Controller.ChooseControlledCreaturesOptionally(
            2, game, ToString());
        game.AddDelayedTriggeredAbility(
            factory.Create(
                Ability, Guid.NewGuid(), [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new LunarChargerEffect(this);
    }
}
