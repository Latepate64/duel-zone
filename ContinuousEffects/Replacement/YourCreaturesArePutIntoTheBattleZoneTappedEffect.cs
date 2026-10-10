using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Replacement;

/// <summary>
/// Your creatures are put into the battle zone tapped.
/// </summary>
public sealed class YourCreaturesArePutIntoTheBattleZoneTappedEffect
    : ReplacementEffect
{
    private readonly ICardFilter filter;

    public YourCreaturesArePutIntoTheBattleZoneTappedEffect(ICardFilter filter)
    {
        this.filter = filter;
    }

    public YourCreaturesArePutIntoTheBattleZoneTappedEffect(
        YourCreaturesArePutIntoTheBattleZoneTappedEffect effect) : base(
        effect)
    {
        filter = effect.filter.Copy();
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        if (gameEvent is not ICardMovedEvent e) return false;
        if (e.Destination != ZoneType.BattleZone) return false;
        var card = game.GetCard(e.CardInSourceZone);
        if (!card.Owner.Equals(Controller)) return false;
        if (!filter.Match(card)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new YourCreaturesArePutIntoTheBattleZoneTappedEffect(this);
    }
}
