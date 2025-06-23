using Interfaces;

namespace OneShotEffects;

public sealed class LunarChargerEffect : OneShotEffect
{
    public LunarChargerEffect()
    {
    }

    public LunarChargerEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var creatures = Controller.ChooseControlledCreaturesOptionally(2, game, ToString());
        throw new NotImplementedException();
        // game.AddDelayedTriggeredAbility(new LunarChargerDelayedTriggeredAbility(Ability, creatures, game.CurrentTurn.Id));
    }

    public override IOneShotEffect Copy()
    {
        return new LunarChargerEffect(this);
    }

    public override string ToString()
    {
        return "Choose up to 2 of your creatures in the battle zone. At the end of the turn, you may untap them.";
    }
}
