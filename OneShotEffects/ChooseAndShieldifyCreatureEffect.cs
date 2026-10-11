using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose a creature in the battle zone and add it to its owner's shields face
/// down.
/// </summary>
public sealed class ChooseAndShieldifyCreatureEffect
    : CardMovingChoiceEffect<ICreature>
{
    private readonly ICardFilter filter;

    public ChooseAndShieldifyCreatureEffect(ICardFilter filter) : base(
        1, 1, true, ZoneType.BattleZone, ZoneType.ShieldZone)
    {
        this.filter = filter;
    }

    public ChooseAndShieldifyCreatureEffect(
        ChooseAndShieldifyCreatureEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ChooseAndShieldifyCreatureEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(Applier, filter, game);
    }
}
