using CardFilters;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.Replacement;

/// <summary>
/// Your creatures that have \"silent skill\" are put into the battle zone
/// tapped.
/// </summary>
public sealed class MysticMagicianTappedEffect : ReplacementEffect
{
    private readonly ICardFilter filter = new SilentSkillFilter();

    public MysticMagicianTappedEffect()
    {
    }

    public MysticMagicianTappedEffect(MysticMagicianTappedEffect effect) : base(
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
        return new MysticMagicianTappedEffect(this);
    }
}
