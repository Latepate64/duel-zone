using Interfaces;

namespace OneShotEffects;

/// <summary>
/// One of your creatures in the battle zone gets +4000 power until the end of
/// the turn.
/// </summary>
public sealed class ProtectiveForceEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;

    public ProtectiveForceEffect(ICardFilter filter) : base(1, 1, true)
    {
        this.filter = filter;
    }

    public ProtectiveForceEffect(ProtectiveForceEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ProtectiveForceEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        throw new NotImplementedException();
        // game.AddContinuousEffects(Ability,
        // new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(
        //     4000, cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
    }
}
