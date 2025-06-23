using TriggeredAbilities;
using ContinuousEffects;
using Engine.Abilities;
using OneShotEffects;
using Interfaces.ContinuousEffects;
using Interfaces;

namespace Cards.DM07;

sealed class SiriEffect : ContinuousEffect, IAbilityAddingEffect
{
    public SiriEffect() : base()
    {
    }

    public SiriEffect(SiriEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        if (!Controller.ShieldZone.HasCards)
        {
            game.AddAbility(Source, new StaticAbility(new ThisCreatureHasBlockerEffect()));
            game.AddAbility(Source, new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }

    public override IContinuousEffect Copy()
    {
        return new SiriEffect(this);
    }

    public override string ToString()
    {
        return "While you have no shields, this creature has \"blocker\" and \"At the end of each of your turns, you may untap this creature.\"";
    }
}
