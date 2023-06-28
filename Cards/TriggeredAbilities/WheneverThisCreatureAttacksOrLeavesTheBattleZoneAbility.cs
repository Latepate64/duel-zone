using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    class WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility : TriggeredAbility
    {
        public WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return (gameEvent is CreatureAttackedEvent e && e.Attacker == Source) || (gameEvent is CardMovedEvent f && f.Source == ZoneType.BattleZone && Game.GetCard(f.CardInSourceZone) == Source);
        }

        public override IAbility Copy()
        {
            return new WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever this creature attacks or leaves the battle zone, {GetEffectText()}";
        }
    }
}
