using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each of your other light creatures in the battle zone has \"blocker.\"
/// </summary>
public sealed class SiegBaliculaTheIntenseEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    public SiegBaliculaTheIntenseEffect() : base() { }

    public void AddAbility(IGame game)
    {
        var creatures =
            game.BattleZone.GetOtherCivilizationCreaturesControllerByPlayer(
                (ICreature)Source!, Civilization.Light);
        foreach (var creature in creatures)
        {
            game.AddAbility(creature, new BlockerAbility());
        }
    }

    public bool CanBlock(ICreature blocker, ICreature attacker)
    {
        var ability = Ability;
        return blocker.Owner == ability.Controller && blocker != ability.Source && blocker.HasCivilization(
            Civilization.Light);
    }

    public override IContinuousEffect Copy()
    {
        return new SiegBaliculaTheIntenseEffect();
    }
}
