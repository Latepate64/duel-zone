using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class WhenYouPutThisCreatureIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public WhenYouPutThisCreatureIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect, new TargetFilter())
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

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return Source == card.Id;
        }
    }

    class WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect, new CardFilters.AnotherBattleZoneCreatureFilter())
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

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return Source != card.Id;
        }
    }

    class WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect, new CardFilters.YourDragonoidOrDragonFilter())
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

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return Controller == card.Owner && (card.HasSubtype(Subtype.Dragonoid) || card.IsDragon);
        }
    }

    class WhenYouPutAnotherCreatureIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(WhenYouPutAnotherCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(IOneShotEffect effect) : base(effect, new CardFilters.OwnersOtherBattleZoneCreatureFilter())
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

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return Source != card.Id && Controller == card.Owner;
        }
    }

    public abstract class WheneverCreatureIsPutIntoTheBattleZoneAbility : CardChangesZoneAbility
    {
        protected WheneverCreatureIsPutIntoTheBattleZoneAbility(WheneverCreatureIsPutIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        protected WheneverCreatureIsPutIntoTheBattleZoneAbility(IOneShotEffect effect, ICardFilter filter) : base(effect, filter)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CardMovedEvent e && e.Destination == ZoneType.BattleZone;
        }
    }

    class WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        private readonly Subtype _subtype;

        public WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility(WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
            _subtype = ability._subtype;
        }

        public WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility(Subtype subtype, IOneShotEffect effect) : base(effect, new CardFilters.OwnersBattleZoneSubtypeCreatureFilter(subtype))
        {
            _subtype = subtype;
        }

        public override IAbility Copy()
        {
            return new WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever you put a {_subtype} into the battle zone, {GetEffectText()}";
        }

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return Controller == card.Owner && card.HasSubtype(_subtype);
        }
    }
}

