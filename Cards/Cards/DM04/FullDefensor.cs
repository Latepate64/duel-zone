using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;
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

    class FullDefensorEffect : OneShotAreaOfEffect
    {
        public FullDefensorEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
        {
        }

        public FullDefensorEffect(FullDefensorEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new FullDefensorContinuousEffect(source.Controller, GetAffectedCards(game, source).ToArray()));
            return null;
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

    class FullDefensorContinuousEffect : AbilityAddingEffect, IDuration
    {
        private readonly Guid _player;

        public FullDefensorContinuousEffect(FullDefensorContinuousEffect effect) : base(effect)
        {
            _player = effect._player;
        }

        public FullDefensorContinuousEffect(Guid player, params Engine.ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new StaticAbilities.BlockerAbility())
        {
            _player = player;
        }

        public override IContinuousEffect Copy()
        {
            return new FullDefensorContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.StartOfTurn && phase.Turn.ActivePlayerId == _player;
        }

        public override string ToString()
        {
            return "Until the start of your next turn, each of your creatures in the battle zone has \"Blocker\".";
        }
    }
}
