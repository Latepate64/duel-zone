using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each of your creatures in the battle zone has "speed attacker."
/// </summary>
public sealed class MagmadragonJagalzorEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    public MagmadragonJagalzorEffect() : base()
    {
    }

    public MagmadragonJagalzorEffect(MagmadragonJagalzorEffect effect) : base(
        effect)
    {
    }

    public void AddAbility(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControllerByPlayer(
            Source!.OwnerV2);
        foreach (var creature in creatures)
        {
            game.AddAbility(creature, new SpeedAttackerAbility());
        }
    }

    public override IContinuousEffect Copy()
    {
        return new MagmadragonJagalzorEffect(this);
    }
}
