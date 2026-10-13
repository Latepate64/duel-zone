using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Your opponent chooses up to x creatures in his hand and puts them into the
/// battle zone.
/// </summary>
public sealed class StratosphereGiantEffect : CardMovingChoiceEffect
{
    public StratosphereGiantEffect(
        int minimum, int maximum, ICardFilter filter) : base(
            minimum, maximum, false, filter, ZoneType.Hand, ZoneType.BattleZone)
    {
    }

    public StratosphereGiantEffect(
        StratosphereGiantEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new StratosphereGiantEffect(this);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(
        IGame game, IAbility source)
    {
        return GetOpponent(game).Hand.Creatures;
    }
}
