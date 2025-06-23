using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class CratersaurEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect, IAbilityAddingEffect
{
    public CratersaurEffect() : base()
    {
    }

    public void AddAbility(IGame game)
    {
        if (YouHaveNoShields(game))
        {
            Source.AddGrantedAbility(new StaticAbility(new PowerAttackerEffect(3000)));
        }
    }

    public bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return YouHaveNoShields(game) && IsSourceOfAbility(attacker);
    }

    public override IContinuousEffect Copy()
    {
        return new CratersaurEffect();
    }

    public override string ToString()
    {
        return "While you have no shields, this creature can attack untapped creatures and has \"Power attacker +3000.\"";
    }

    private bool YouHaveNoShields(IGame game)
    {
        return !Ability.Controller.ShieldZone.HasCards;
    }
}
