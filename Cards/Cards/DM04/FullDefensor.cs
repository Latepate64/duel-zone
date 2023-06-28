﻿using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class FullDefensor : Spell
    {
        public FullDefensor() : base("Full Defensor", 2, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new FullDefensorEffect());
        }
    }

    class FullDefensorEffect : OneShotEffect
    {
        public FullDefensorEffect() : base()
        {
        }

        public FullDefensorEffect(FullDefensorEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            Game.AddContinuousEffects(Ability, new FullDefensorContinuousEffect(Applier.Id, Game.BattleZone.GetCreatures(Applier).ToArray()));
        }

        public override IOneShotEffect Copy()
        {
            return new FullDefensorEffect(this);
        }

        public override string ToString()
        {
            return "Until the start of your next turn, each of your creatures in the battle zone gets \"Blocker\".";
        }
    }

    class FullDefensorContinuousEffect : AbilityAddingEffect, IExpirable
    {
        private readonly Guid _player;
        private readonly ICard[] _cards;

        public FullDefensorContinuousEffect(FullDefensorContinuousEffect effect) : base(effect)
        {
            _player = effect._player;
            _cards = effect._cards;
        }

        public FullDefensorContinuousEffect(Guid player, params ICard[] cards) : base(new StaticAbilities.BlockerAbility())
        {
            _player = player;
            _cards = cards;
        }

        public override IContinuousEffect Copy()
        {
            return new FullDefensorContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn && phase.Turn.ActivePlayer.Id == _player;
        }

        public override string ToString()
        {
            return "Until the start of your next turn, each of your creatures in the battle zone has \"Blocker\".";
        }

        protected override IEnumerable<ICard> GetAffectedCards()
        {
            return _cards;
        }
    }
}
