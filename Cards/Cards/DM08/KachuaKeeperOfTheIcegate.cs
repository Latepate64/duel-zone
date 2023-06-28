﻿using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System;
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

        public override void Apply()
        {
            var cards = Applier.Deck.Creatures.Where(x => x.IsDragon);
            var dragon = Applier.ChooseCardOptionally(cards, ToString());
            if (dragon != null)
            {
                Game.Move(Ability, ZoneType.Deck, ZoneType.Hand, dragon);
            }
            Applier.ShuffleOwnDeck();
            if (dragon != null)
            {
                Game.AddContinuousEffects(Ability, new KachuaContinuousEffect(dragon));
                Game.AddDelayedTriggeredAbility(new KachuaDelayedTriggeredAbility(Ability, dragon, Game.CurrentTurn.Id));
            }
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

    class KachuaContinuousEffect : ContinuousEffect, ISpeedAttackerEffect, ICardAffectable
    {
        public KachuaContinuousEffect(ICard card)
        {
            Card = card;
        }

        public KachuaContinuousEffect(KachuaContinuousEffect effect) : base(effect)
        {
            Card = effect.Card;
        }

        public ICard Card { get; }

        public bool Applies(ICard creature)
        {
            return creature == Card;
        }

        public override IContinuousEffect Copy()
        {
            return new KachuaContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{Card} has \"speed attacker.\"";
        }
    }

    class KachuaDelayedTriggeredAbility : DelayedTriggeredAbility
    {
        public KachuaDelayedTriggeredAbility(IAbility source, ICard card, Guid turnId) : base(new KachuaAbility(card, turnId), true, source)
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

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent e && e.Phase.Type == PhaseOrStep.EndOfTurn && e.Turn.Id == _turnId;
        }

        public override IAbility Copy()
        {
            return new KachuaAbility(this);
        }

        public override void Resolve()
        {
            Game.Destroy(this,  _card);
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
