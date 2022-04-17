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

    class SnorkLaAbility : TriggeredAbility
    {
        public SnorkLaAbility() : base(new SnorkLaEffect())
        {
        }

        public SnorkLaAbility(SnorkLaAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CardMovedEvent e && e.Ability?.Controller == GetController(game).Id && e.Source == ZoneType.ManaZone && e.Destination == ZoneType.Graveyard;
        }

        public override IAbility Copy()
        {
            return new SnorkLaAbility(this);
        }

        public override string ToString()
        {
            return "Whenever your opponent causes a card to be put into your graveyard from your mana zone, you may return that card to your mana zone.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            var ability = base.Trigger(source, owner, gameEvent);
            ability.OneShotEffect = new SnorkLaEffect((gameEvent as CardMovedEvent).CardInDestinationZone);
            return ability;
        }
    }

    class SnorkLaEffect : OneShotEffect
    {
        private readonly ICard _card;

        public SnorkLaEffect()
        {
        }

        public SnorkLaEffect(ICard card)
        {
            _card = card;
        }

        public SnorkLaEffect(SnorkLaEffect effect) : base(effect)
        {
            _card = effect._card?.Copy();
        }

        public override object Apply(IGame game, IAbility source)
        {
            if (source.GetController(game).ChooseToTakeAction(ToString()))
            {
                game.Move(source, ZoneType.Graveyard, ZoneType.ManaZone, _card);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SnorkLaEffect(this);
        }

        public override string ToString()
        {
            return $"You may return {_card} to your mana zone.";
        }
    }
}
