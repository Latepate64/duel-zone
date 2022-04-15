using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class ThreeEyedDragonfly : Creature
    {
        public ThreeEyedDragonfly() : base("Three-Eyed Dragonfly", 5, 4000, Engine.Subtype.GiantInsect, Engine.Civilization.Nature)
        {
            AddWheneverThisCreatureAttacksAbility(new ThreeEyedDragonflyOneShotEffect());
        }
    }

    class ThreeEyedDragonflyOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var destroyed = new YouMayDestroyOneOfYourOtherCreaturesEffect().Apply(game, source);
            if (destroyed.Any())
            {
                game.AddContinuousEffects(source, new ThreeEyedDragonflyContinuousEffect(game.GetCard(source.Source)));
            }
            return destroyed;
        }

        public override IOneShotEffect Copy()
        {
            return new ThreeEyedDragonflyOneShotEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your other creatures. If you do, this creature gets +2000 power and has \"double breaker\" until the end of the turn.";
        }
    }

    class ThreeEyedDragonflyContinuousEffect : GetPowerAndDoubleBreakerEffect, IDuration
    {
        private readonly ICard _card;

        public ThreeEyedDragonflyContinuousEffect(ThreeEyedDragonflyContinuousEffect effect) : base(effect)
        {
            _card = effect._card;
        }

        public ThreeEyedDragonflyContinuousEffect(ICard card) : base(2000)
        {
            _card = card;
        }

        public override IContinuousEffect Copy()
        {
            return new ThreeEyedDragonflyContinuousEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets +2000 power and has \"double breaker\" until the end of the turn.";
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }

        protected override List<ICard> GetAffectedCards(IGame game)
        {
            return new List<ICard> { _card };
        }
    }

    class YouMayDestroyOneOfYourOtherCreaturesEffect : DestroyEffect
    {
        public YouMayDestroyOneOfYourOtherCreaturesEffect(YouMayDestroyOneOfYourOtherCreaturesEffect effect) : base(effect)
        {
        }

        public YouMayDestroyOneOfYourOtherCreaturesEffect() : base(0, 1, true)
        {
        }

        public override string ToString()
        {
            return "You may destroy one of your other creatures.";
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyOneOfYourOtherCreaturesEffect(this);
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetOtherCreatures(source.Controller, source.Source);
        }
    }
}
