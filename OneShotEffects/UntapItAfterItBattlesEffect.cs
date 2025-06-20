using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class UntapItAfterItBattlesEffect : OneShotEffect
{
    public UntapItAfterItBattlesEffect()
    {
    }

    public UntapItAfterItBattlesEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        throw new NotImplementedException();
        // game.AddDelayedTriggeredAbility(new AfterBattleDelayedTriggeredAbility(new UntapThisCreatureEffect(), Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new UntapItAfterItBattlesEffect(this);
    }

    public override string ToString()
    {
        return "Untap it after it battles.";
    }
}
