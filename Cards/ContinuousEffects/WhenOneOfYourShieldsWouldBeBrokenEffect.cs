using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class WhenOneOfYourShieldsWouldBeBrokenEffect : ReplacementEffect
    {
        protected WhenOneOfYourShieldsWouldBeBrokenEffect()
        {
        }

        protected WhenOneOfYourShieldsWouldBeBrokenEffect(WhenOneOfYourShieldsWouldBeBrokenEffect effect) : base(effect)
        {
        }

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is ShieldsBreakEvent e && e.Shields.First().OwnerPlayer == Controller;
        }
    }

    class WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect : WhenOneOfYourShieldsWouldBeBrokenEffect
    {
        public WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect()
        {
        }

        public WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect(WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            var e = gameEvent as ShieldsBreakEvent;
            var shield = Controller.ChooseCardOptionally(e.Shields, ToString());
            if (shield != null)
            {
                return new WheOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEvent(Source, e.Shields.Where(x => x != shield));
            }
            else
            {
                return gameEvent;
            }
        }

        public override IContinuousEffect Copy()
        {
            return new WhenOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEffect(this);
        }

        public override string ToString()
        {
            return "When one of your shields would be broken, you may destroy this creature instead.";
        }
    }

    class WheOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEvent : GameEvent
    {
        private readonly ICard _creature;
        private readonly IEnumerable<ICard> _remainingShields;

        public WheOneOfYourShieldsWouldBeBrokenYouMayDestroyThisCreatureInsteadEvent(ICard creature, IEnumerable<ICard> remainingShields)
        {
            _creature = creature;
            _remainingShields = remainingShields;
        }

        public override void Happen(IGame game)
        {
            game.Destroy(null, _creature);
            game.PutFromShieldZoneToHand(_remainingShields, true, null);
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
