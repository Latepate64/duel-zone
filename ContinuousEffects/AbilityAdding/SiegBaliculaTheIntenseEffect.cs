using Abilities.Static;
using CardFilters;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Each of your other light creatures in the battle zone has \"blocker.\"
/// </summary>
public sealed class SiegBaliculaTheIntenseEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    private readonly ICardFilter filter = new CivilizationCreatureFilter(
        Civilization.Light);

    public SiegBaliculaTheIntenseEffect() : base() { }

    public SiegBaliculaTheIntenseEffect(
        SiegBaliculaTheIntenseEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public void AddAbility(IGame game)
    {
        var creatures = game.BattleZone.GetOtherCreaturesControlledByPlayer(
            (ICreature)Source!, filter);
        foreach (var creature in creatures)
        {
            game.AddAbility(creature, new BlockerAbility());
        }
    }

    public override IContinuousEffect Copy()
    {
        return new SiegBaliculaTheIntenseEffect(this);
    }
}
