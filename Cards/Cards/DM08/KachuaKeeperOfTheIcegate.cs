using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM08
{
    class KachuaKeeperOfTheIcegate : Creature
    {
        public KachuaKeeperOfTheIcegate() : base("Kachua, Keeper of the Icegate", 7, 3000, Race.SnowFaerie, Civilization.Nature)
        {
            AddTapAbility(new KachuaEffect());
        }
    }

    class KachuaEffect : OneShotEffect
    {
        public KachuaEffect()
        {
        }

        public KachuaEffect(KachuaEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            var cards = source.GetController(game).Deck.Creatures.Where(x => x.IsDragon);
            var dragon = source.GetController(game).ChooseCardOptionally(cards, ToString());
            game.Move(source, ZoneType.Deck, ZoneType.Hand, dragon);
            source.GetController(game).ShuffleDeck(game);
            if (dragon != null)
            {
                game.AddContinuousEffects(source, new KachuaContinuousEffect(dragon));
                game.AddDelayedTriggeredAbility(new KachuaDelayedTriggeredAbility(source, dragon, game.CurrentTurn.Id));
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new KachuaEffect(this);
        }

        public override string ToString()
        {
            return "Search your deck. You may take a creature that has Dragon in its race from your deck and put it into the battle zone. Then shuffle your deck. That creature has \"speed attacker.\" At the end of the turn, destroy it.";
        }
    }

    class KachuaContinuousEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        private readonly ICard _card;

        public KachuaContinuousEffect(ICard card)
        {
            _card = card;
        }

        public KachuaContinuousEffect(KachuaContinuousEffect effect) : base(effect)
        {
            _card = effect._card;
        }

        public bool Applies(ICard creature, IGame game)
        {
            return creature == _card;
        }

        public override IContinuousEffect Copy()
        {
            return new KachuaContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{_card} has \"speed attacker.\"";
        }
    }

    class KachuaDelayedTriggeredAbility : DelayedTriggeredAbility
    {
        public KachuaDelayedTriggeredAbility(IAbility source, ICard card, Guid turnId) : base(new KachuaAbility(card, turnId), source.Source, source.Controller, true)
        {
        }
    }

    class KachuaAbility : LinkedTriggeredAbility
    {
        private readonly ICard _card;
        private readonly Guid _turnId;

        public KachuaAbility(ICard card, Guid turnId)
        {
            _card = card;
            _turnId = turnId;
        }

        public KachuaAbility(KachuaAbility ability) : base(ability)
        {
            _card = ability._card;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent e && e.Phase.Type == PhaseOrStep.EndOfTurn && e.Turn.Id == _turnId;
        }

        public override IAbility Copy()
        {
            return new KachuaAbility(this);
        }

        public override void Resolve(IGame game)
        {
            game.Destroy(this, new List<ICard> { _card });
        }

        public override string ToString()
        {
            return $"Destroy {_card}.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            return new KachuaAbility(this);
        }
    }
}
