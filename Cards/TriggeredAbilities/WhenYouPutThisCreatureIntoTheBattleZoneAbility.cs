using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    public class WhenYouPutThisCreatureIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public WhenYouPutThisCreatureIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WhenYouPutThisCreatureIntoTheBattleZoneAbility(WhenYouPutThisCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new WhenYouPutThisCreatureIntoTheBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"When you put this creature into the battle zone, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card)
        {
            return Source == card;
        }
    }

    class WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public override IAbility Copy()
        {
            return new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever another creature is put into the battle zone, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card)
        {
            return Source != card;
        }
    }

    class WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public override IAbility Copy()
        {
            return new WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever you put a Dragonoid or a creature that has Dragon in its race into the battle zone, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card)
        {
            return Controller == card.Owner && (card.HasRace(Race.Dragonoid) || card.IsDragon);
        }
    }

    class WhenYouPutAnotherCreatureIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(WhenYouPutAnotherCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public override IAbility Copy()
        {
            return new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"When you put another creature into the battle zone, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card)
        {
            return Source != card && Controller == card.Owner;
        }
    }

    public abstract class WheneverCreatureIsPutIntoTheBattleZoneAbility : CardChangesZoneAbility
    {
        protected WheneverCreatureIsPutIntoTheBattleZoneAbility(WheneverCreatureIsPutIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        protected WheneverCreatureIsPutIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is ICardMovedEvent e && e.Destination == ZoneType.BattleZone && TriggersFrom(e.CardInDestinationZone);
        }
    }

    class WheneverYouPutRaceCreatureIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        private readonly Race _race;

        public WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(WheneverYouPutRaceCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
            _race = ability._race;
        }

        public WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(Race race, IOneShotEffect effect) : base(effect)
        {
            _race = race;
        }

        public override IAbility Copy()
        {
            return new WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever you put a {_race} into the battle zone, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card)
        {
            return Controller == card.Owner && card.HasRace(_race);
        }
    }
}

