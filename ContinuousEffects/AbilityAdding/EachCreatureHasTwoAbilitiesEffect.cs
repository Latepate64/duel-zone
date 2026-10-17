using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class EachCreatureHasTwoAbilitiesEffect : AbilityAddingEffect
{
    private readonly ICardFilter filter;

    public EachCreatureHasTwoAbilitiesEffect(
        ICardFilter filter,
        int power,
        IStaticAbilityWithIntegerFactory abilityWithIntegerFactory,
        IStaticAbilityFactory abilityFactory
    ) : base(
        abilityWithIntegerFactory.Create(power),
        abilityFactory.Create())
    {
        this.filter = filter;
    }

    private EachCreatureHasTwoAbilitiesEffect(EachCreatureHasTwoAbilitiesEffect effect) : base(
        effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new EachCreatureHasTwoAbilitiesEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Applier, filter, SelectionRange.AllCards);
    }
}
