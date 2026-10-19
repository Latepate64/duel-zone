using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public sealed class EachOfYourCreaturesGetsPowerAndAbilitiesEffect : ContinuousEffect,
    IPowerModifyingEffect, IAbilityAddingEffect
{
    private readonly ICardFilter filter;
    private readonly int power;
    private readonly IAbility[] abilities;

    public EachOfYourCreaturesGetsPowerAndAbilitiesEffect(
        ICardFilter filter, int power, params IAbility[] abilities) : base()
    {
        this.filter = filter;
        this.power = power;
        this.abilities = abilities;
    }

    private EachOfYourCreaturesGetsPowerAndAbilitiesEffect(
        EachOfYourCreaturesGetsPowerAndAbilitiesEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        power = effect.power;
        abilities = [.. effect.abilities.Select(x => x.Copy())];
    }

    public void AddAbility(IGame game)
    {
        foreach (var card in GetAffectedCards(game))
        {
            foreach (var ability in abilities)
            {
                card.AddGrantedAbility(ability);
            }
        }
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourCreaturesGetsPowerAndAbilitiesEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        GetAffectedCards(game).ForEach(x => x.IncreasePower(power));
    }

    private List<ICreature> GetAffectedCards(IGame game)
    {
        return [.. game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter)];
    }
}
