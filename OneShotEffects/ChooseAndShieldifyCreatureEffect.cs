using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose a creature in the battle zone and add it to its owner's shields face
/// down.
/// </summary>
public sealed class ChooseAndShieldifyCreatureEffect
    : CardMovingChoiceEffect<ICreature>
{

    public ChooseAndShieldifyCreatureEffect(ICardFilter filter) : base(
        1, 1, true, filter, ZoneType.BattleZone, ZoneType.ShieldZone)
    {
    }

    public ChooseAndShieldifyCreatureEffect(
        ChooseAndShieldifyCreatureEffect effect) : base(effect)
    {
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
