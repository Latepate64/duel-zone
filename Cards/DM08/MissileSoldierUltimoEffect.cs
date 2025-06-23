using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM08;

public sealed class MissileSoldierUltimoEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect,
    IAbilityAddingEffect
{
    public MissileSoldierUltimoEffect() : base()
    {
    }

    public MissileSoldierUltimoEffect(MissileSoldierUltimoEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        Source.AddGrantedAbility(new StaticAbility(new PowerAttackerEffect(4000)));
    }

    public bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return IsSourceOfAbility(attacker);
    }

    public override IContinuousEffect Copy()
    {
        return new MissileSoldierUltimoEffect(this);
    }

    public override string ToString()
    {
        return "This creature can attack untapped creatures and has \"Power attacker +4000.\"";
    }
}
