using Interfaces;

namespace OneShotEffects;

/// <summary>
/// You may choose one of your opponent's creatures in the battle zone and put
/// the top card of that creature into your opponent's graveyard.
/// </summary>
public sealed class PouchShellEffect : CreatureSelectionEffect
{
    private readonly ICardFilter filter;

    public PouchShellEffect(ICardFilter filter) : base(0, 1, true)
    {
        this.filter = filter;
    }

    public PouchShellEffect(PouchShellEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new PouchShellEffect(this);
    }

    protected override void Apply(
        IGame game, IAbility source, params ICreature[] cards)
    {
        cards.ToList().ForEach(x => game.MoveTopCard(
            x, ZoneType.Graveyard, source));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetOpponentsChoosableCreatures(
            Applier, filter, game);
    }
}
