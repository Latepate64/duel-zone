using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each of your creatures in the battle zone that has "silent skill" has
/// "speed attacker."
/// </summary>
public sealed class BurnwispLizardEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    public BurnwispLizardEffect() : base()
    {
    }

    public BurnwispLizardEffect(BurnwispLizardEffect effect) : base(effect)
    {
    }

    public void AddAbility(IGame game)
    {
        var creatures =
            game.BattleZone.GetCreaturesWithSilentSkillControllerByPlayer(
                Source!.OwnerV2);
        foreach (var creature in creatures)
        {
            game.AddAbility(creature, new SpeedAttackerAbility());
        }
    }

    public override IContinuousEffect Copy()
    {
        return new BurnwispLizardEffect(this);
    }
}
