using GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class MysticMagicianTappedEffect : ReplacementEffect
{
    public MysticMagicianTappedEffect()
    {
    }

    public MysticMagicianTappedEffect(MysticMagicianTappedEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        return new CardMovedEvent(gameEvent as ICardMovedEvent)
        {
            Destination = ZoneType.BattleZone,
            EntersTapped = true,
        };
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is ICardMovedEvent e && e.Destination == ZoneType.BattleZone
            && game.GetCard(e.CardInSourceZone).Owner == Controller
            && game.GetCard(e.CardInSourceZone).GetAbilities<Abilities.SilentSkillAbility>().Any();
    }

    public override IContinuousEffect Copy()
    {
        return new MysticMagicianTappedEffect(this);
    }

    public override string ToString()
    {
        return "Your creatures that have \"silent skill\" are put into the battle zone tapped.";
    }
}
