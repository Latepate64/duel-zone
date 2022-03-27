using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class WhenYouPutThisCreatureIntoTheBattleZoneAbility : CardChangesZoneAbility
    {
        public WhenYouPutThisCreatureIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WhenYouPutThisCreatureIntoTheBattleZoneAbility(WhenYouPutThisCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CardMovedEvent e && e.Destination == ZoneType.BattleZone;
        }

        public override IAbility Copy()
        {
            return new WhenYouPutThisCreatureIntoTheBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"When you put this creature into the battle zone, {GetEffectText()}";
        }
    }

    public class WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility : CardChangesZoneAbility
    {
        public WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect, new CardFilters.AnotherBattleZoneCreatureFilter())
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CardMovedEvent e && e.Destination == ZoneType.BattleZone;
        }

        public override IAbility Copy()
        {
            return new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever another creature is put into the battle zone, {GetEffectText()}";
        }
    }
}

