using Abilities.Static;
using CardFilters;
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
    private readonly ICardFilter filter = new SilentSkillFilter();

    public BurnwispLizardEffect() : base()
    {
    }

    public BurnwispLizardEffect(BurnwispLizardEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public void AddAbility(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControllerByPlayer(
            Source!.OwnerV2, filter);
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
