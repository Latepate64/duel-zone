using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each creature in the battle zone that has Dragon in its race has "speed
/// attacker."
/// </summary>
public sealed class TottoPipicchiEffect : ContinuousEffect, IAbilityAddingEffect
{
    public TottoPipicchiEffect() : base()
    {
    }

    public TottoPipicchiEffect(TottoPipicchiEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        foreach (var creature in game.BattleZone.Dragons)
        {
            game.AddAbility(creature, new SpeedAttackerAbility());
        }
    }

    public override IContinuousEffect Copy()
    {
        return new TottoPipicchiEffect(this);
    }
}
