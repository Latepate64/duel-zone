using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public sealed class EachCreatureGetsPowerAndAbilityEffect : ContinuousEffect, IPowerModifyingEffect,
    IAbilityAddingEffect
{
    private readonly ICardFilter filter;
    private readonly int power;
    private readonly IAbility ability;

    public EachCreatureGetsPowerAndAbilityEffect(
        ICardFilter filter, int power, IAbility ability) : base()
    {
        this.filter = filter;
        this.power = power;
        this.ability = ability;
    }

    private EachCreatureGetsPowerAndAbilityEffect(
        EachCreatureGetsPowerAndAbilityEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        power = effect.power;
        ability = effect.ability.Copy();
    }

    public void AddAbility(IGame game)
    {
        GetAffectedCards(game).ForEach(x => x.AddGrantedAbility(ability));
    }

    public override IContinuousEffect Copy()
    {
        return new EachCreatureGetsPowerAndAbilityEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        GetAffectedCards(game).ForEach(x => x.IncreasePower(power));
    }

    private List<ICreature> GetAffectedCards(IGame game)
    {
        return [.. game.BattleZone.GetCreatures(Applier, filter, SelectionRange.AllCards)];
    }
}
