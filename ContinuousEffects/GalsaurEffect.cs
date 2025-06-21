using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class GalsaurEffect : ContinuousEffect, IAbilityAddingEffect
{
    public GalsaurEffect() : base()
    {
    }

    public void AddAbility(IGame game)
    {
        var ability = Ability;
        if (!game.BattleZone.GetCreatures(ability.Controller.Id).Any(x => x != ability.Source))
        {
            Source.AddGrantedAbility(new StaticAbility(new PowerAttackerEffect(4000)));
            Source.AddGrantedAbility(new StaticAbility(new DoubleBreakerEffect()));
        }
    }

    public override IContinuousEffect Copy()
    {
        return new GalsaurEffect();
    }

    public override string ToString()
    {
        return "While you have no other creatures in the battle zone, this creature has \"power attacker +4000\" and \"double breaker.\"";
    }
}
