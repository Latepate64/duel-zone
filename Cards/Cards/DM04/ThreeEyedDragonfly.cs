using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System.Collections.Generic;

namespace Cards.Cards.DM04
{
    class ThreeEyedDragonfly : Creature
    {
        public ThreeEyedDragonfly() : base("Three-Eyed Dragonfly", 5, 4000, Race.GiantInsect, Civilization.Nature)
        {
            AddWheneverThisCreatureAttacksAbility(new ThreeEyedDragonflyOneShotEffect());
        }
    }

    class ThreeEyedDragonflyOneShotEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var creature = Applier.ChooseCardOptionally(game.BattleZone.GetOtherCreatures(Ability.Controller.Id, Ability.Source.Id), ToString());
            if (creature != null)
            {
                game.Destroy(Ability, creature);
                game.AddContinuousEffects(Ability, new ThreeEyedDragonflyContinuousEffect(Ability.Source));
            }
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

    class ThreeEyedDragonflyContinuousEffect : GetPowerAndDoubleBreakerEffect, IExpirable
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

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }

        protected override List<ICard> GetAffectedCards(IGame game)
        {
            return new List<ICard> { _card };
        }
    }
}
