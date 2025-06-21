using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public class DestroyAfterBattleEffect : OneShotEffect
{
    public DestroyAfterBattleEffect()
    {
    }

    public DestroyAfterBattleEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        throw new NotImplementedException();
        // game.AddDelayedTriggeredAbility(new AfterBattleDelayedTriggeredAbility(
        //     new DestroyThisCreatureEffect(), Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyAfterBattleEffect(this);
    }

    public override string ToString()
    {
        return "Destroy it after the battle.";
    }
}
