using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Your opponent chooses up to x creatures in his hand and puts them into the
/// battle zone.
/// </summary>
public sealed class StratosphereGiantEffect : CardMovingChoiceEffect<ICreature>
{
    private readonly ICardFilter filter;

    public StratosphereGiantEffect(
        int minimum, int maximum, ICardFilter filter) : base(
            minimum, maximum, false, ZoneType.Hand, ZoneType.BattleZone)
    {
        this.filter = filter;
    }

    public StratosphereGiantEffect(
        StratosphereGiantEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
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
