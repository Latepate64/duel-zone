using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using System;

namespace Cards.Cards.DM05
{
    class SnorkLaShrineGuardian : Creature
    {
        public SnorkLaShrineGuardian() : base("Snork La, Shrine Guardian", 3, 3000, Race.Guardian, Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddTriggeredAbility(new SnorkLaAbility());
        }
    }

    class SnorkLaAbility : LinkedTriggeredAbility
    {
        private readonly ICard _card;

        public SnorkLaAbility() : base()
        {
        }

        public SnorkLaAbility(ICard card) : base()
        {
            _card = card;
        }

        public SnorkLaAbility(SnorkLaAbility ability) : base(ability)
        {
            _card = ability._card;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CardMovedEvent e && e.Ability?.Controller == GetController(game).Id && e.Source == ZoneType.ManaZone && e.Destination == ZoneType.Graveyard;
        }

        public override IAbility Copy()
        {
            return new SnorkLaAbility(this);
        }

        public override void Resolve(IGame game)
        {
            if (GetController(game).ChooseToTakeAction(ToString()))
            {
                game.Move(this, ZoneType.Graveyard, ZoneType.ManaZone, _card);
            }
        }

        public override string ToString()
        {
            return "Whenever your opponent causes a card to be put into your graveyard from your mana zone, you may return that card to your mana zone.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            return new SnorkLaAbility((gameEvent as CardMovedEvent).CardInDestinationZone);
        }
    }
}
