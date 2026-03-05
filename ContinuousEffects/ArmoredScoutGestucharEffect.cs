using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ArmoredScoutGestucharEffect : ContinuousEffect, IAbilityAddingEffect
{
    public ArmoredScoutGestucharEffect()
    {
    }

    public ArmoredScoutGestucharEffect(ArmoredScoutGestucharEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        var creature = Source;
        if (game.BattleZone.GetOtherCreatureCount(Controller.Id, creature.Id, Civilization.Fire) == 0)
        {
            creature.AddGrantedAbility(new StaticAbility(new PowerAttackerEffect(3000)));
            creature.AddGrantedAbility(new StaticAbility(new DoubleBreakerEffect()));
        }
    }

    public override IContinuousEffect Copy()
    {
        return new ArmoredScoutGestucharEffect(this);
    }

    public override string ToString()
    {
        return "While you have no other fire creatures in the battle zone, this creature has \"power attacker +3000\" and \"double breaker.\"";
    }
}
