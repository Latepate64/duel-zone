using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose up to 2 of your opponent's creatures in the battle zone. If they have
/// total power less than this creature's power, destroy them.
/// </summary>
public sealed class HeavyweightDragonEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;

    public HeavyweightDragonEffect(ICardFilter filter) : base(0, 2, true)
    {
        this.filter = filter;
    }

    public HeavyweightDragonEffect(HeavyweightDragonEffect effect) : base(
        effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new HeavyweightDragonEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        if (cards.Sum(x => x.Power) < ((ICreature)Ability.Source).Power)
        {
            game.Destroy(source, cards);
        }
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
    }
}
