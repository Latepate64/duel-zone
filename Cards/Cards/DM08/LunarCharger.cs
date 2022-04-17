﻿using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM08
{
    class LunarCharger : Charger
    {
        public LunarCharger() : base("Lunar Charger", 3, Civilization.Light)
        {
            AddSpellAbilities(new LunarChargerEffect());
        }
    }

    class LunarChargerEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var creatures = source.GetController(game).ChooseControlledCreaturesOptionally(2, game, ToString());
            game.AddDelayedTriggeredAbility(new LunarChargerDelayedTriggeredAbility(source, creatures, game.CurrentTurn.Id));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new LunarChargerEffect();
        }

        public override string ToString()
        {
            return "Choose up to 2 of your creatures in the battle zone. At the end of the turn, you may untap them.";
        }
    }

    class LunarChargerDelayedTriggeredAbility : DelayedTriggeredAbility
    {
        public LunarChargerDelayedTriggeredAbility(IAbility source, IEnumerable<ICard> cards, Guid turnId) : base(new LunarChargerAbility(cards, turnId), source.Source, source.Controller, true)
        {
        }
    }

    class LunarChargerAbility : LinkedTriggeredAbility
    {
        private readonly IEnumerable<ICard> _cards;
        private readonly Guid _turnId;

        public LunarChargerAbility(IEnumerable<ICard> cards, Guid turnId)
        {
            _cards = cards;
            _turnId = turnId;
        }

        public LunarChargerAbility(LunarChargerAbility ability) : base(ability)
        {
            _cards = ability._cards;
            _turnId = ability._turnId;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent e && e.Phase.Type == PhaseOrStep.EndOfTurn && e.Turn.Id == _turnId;
        }

        public override IAbility Copy()
        {
            return new LunarChargerAbility(this);
        }

        public override void Resolve(IGame game)
        {
            var cards = GetController(game).ChooseAnyNumberOfCards(_cards, "Choose which creatures to untap.");
            GetController(game).Untap(game, cards.ToArray());
        }

        public override string ToString()
        {
            return $"At the end of the turn, you may untap ${_cards}.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            return new LunarChargerAbility(this);
        }
    }
}