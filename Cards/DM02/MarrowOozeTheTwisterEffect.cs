using TriggeredAbilities;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM02;

public class MarrowOozeTheTwisterEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(
            new AfterAttackDelayedTriggeredAbility(
                new OneShotEffects.DestroyThisCreatureEffect(),
                Ability,
                Ability.Source.Id));
    }

    public override IOneShotEffect Copy()
    {
        return new MarrowOozeTheTwisterEffect();
    }

    public override string ToString()
    {
        return "Destroy it after the attack.";
    }
}
