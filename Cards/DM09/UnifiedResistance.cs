using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.DM09
{
    class UnifiedResistance : Spell
    {
        public UnifiedResistance() : base("Unified Resistance", 2, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new UnifiedResistanceOneShotEffect());
        }
    }

    class UnifiedResistanceOneShotEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var race = Controller.ChooseRace(ToString());
            var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id).Where(x => x.HasRace(race));
            game.AddContinuousEffects(Ability, new UnifiedResistanceContinuousEffect(Ability.Controller.Id, [.. creatures]));
        }

        public override IOneShotEffect Copy()
        {
            return new UnifiedResistanceOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Until the start of your next turn, each of your creatures in the battle zone of that race gets \"Blocker.\"";
        }
    }

    class UnifiedResistanceContinuousEffect : AbilityAddingEffect, IExpirable
    {
        private readonly Guid _player;
        private readonly Card[] _cards;

        public UnifiedResistanceContinuousEffect(UnifiedResistanceContinuousEffect effect) : base(effect)
        {
            _player = effect._player;
            _cards = effect._cards;
        }

        public UnifiedResistanceContinuousEffect(Guid player, params Card[] cards) : base(
            new StaticAbility(new ThisCreatureHasBlockerEffect()))
        {
            _player = player;
            _cards = cards;
        }

        public override IContinuousEffect Copy()
        {
            return new UnifiedResistanceContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn && phase.Turn.ActivePlayer.Id == _player;
        }

        public override string ToString()
        {
            return $"Until the start of your next turn, {_cards} have \"Blocker\".";
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game)
        {
            return _cards;
        }
    }
}
