﻿using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM07
{
    class BattleshipMutant : Creature
    {
        public BattleshipMutant() : base("Battleship Mutant", 6, 5000, Race.Hedrian, Civilization.Darkness)
        {
            AddTapAbility(new BattleshipMutantEffect());
        }
    }

    class BattleshipMutantEffect : OneShotEffect
    {
        public BattleshipMutantEffect()
        {
        }

        public BattleshipMutantEffect(BattleshipMutantEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            Game.AddContinuousEffects(Ability, new BattleshipMutantContinuousEffect());
            Game.AddDelayedTriggeredAbility(new BattleshipMutantDelayedTriggeredAbility(Ability, Game.BattleZone.GetCreatures(Applier, Civilization.Darkness)));
        }

        public override IOneShotEffect Copy()
        {
            return new BattleshipMutantEffect();
        }

        public override string ToString()
        {
            return "Until the end of the turn, each of your darkness creatures in the battle zone gets +4000 power and \"double breaker.\" Whenever any of those creatures battles this turn, destroy it after the battle.";
        }
    }

    class BattleshipMutantContinuousEffect : GetPowerAndDoubleBreakerEffect, IExpirable
    {
        public BattleshipMutantContinuousEffect(BattleshipMutantContinuousEffect effect) : base(effect)
        {
        }

        public BattleshipMutantContinuousEffect() : base(4000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new BattleshipMutantContinuousEffect();
        }

        public override string ToString()
        {
            return "Until the end of the turn, each of your darkness creatures in the battle zone gets +4000 power and \"double breaker.\"";
        }

        protected override List<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(Applier, Civilization.Darkness).ToList();
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class BattleshipMutantDelayedTriggeredAbility : DelayedTriggeredAbility, IExpirable
    {
        public BattleshipMutantDelayedTriggeredAbility(IAbility source, IEnumerable<ICard> cards) : base(new BattleshipMutantAbility(cards), false, source)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }

    class BattleshipMutantAbility : LinkedTriggeredAbility
    {
        private readonly IEnumerable<ICard> _cards;
        private readonly ICard _toDestroy;

        public BattleshipMutantAbility(IEnumerable<ICard> cards)
        {
            _cards = cards;
        }

        public BattleshipMutantAbility(ICard toDestroy)
        {
            _toDestroy = toDestroy;
        }

        public BattleshipMutantAbility(BattleshipMutantAbility ability) : base(ability)
        {
            _cards = ability._cards;
            _toDestroy = ability._toDestroy;
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is BattleEvent e && _cards.Any(x => x == e.AttackingCreature || x == e.DefendingCreature);
        }

        public override IAbility Copy()
        {
            return new BattleshipMutantAbility(this);
        }

        public override void Resolve()
        {
            Game.Destroy(this, _toDestroy);
        }

        public override string ToString()
        {
            return $"Whenever any of {_cards} battles, destroy it after the battle.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            var e = gameEvent as BattleEvent;
            var toDestroy = _cards.Single(x => x == e.AttackingCreature || x == e.DefendingCreature);
            return new BattleshipMutantAbility(toDestroy);
        }
    }
}
