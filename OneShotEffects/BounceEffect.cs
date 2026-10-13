using Interfaces;

namespace OneShotEffects;

public sealed class BounceEffect : CardMovingChoiceEffect
{
    public BounceEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        ICardFilter filter,
        SelectionRange selectionRange) : base(
            minimum,
            maximum,
            controllerChooses,
            filter,
            ZoneType.BattleZone,
            ZoneType.Hand,
            selectionRange)
    {
    }

    BounceEffect(BounceEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BounceEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreatures(
            Applier, filter, game, selectionRange);
    }
}
