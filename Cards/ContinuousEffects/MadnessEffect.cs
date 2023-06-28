using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.ContinuousEffects
{
    abstract class MadnessEffect : ReplacementEffect
    {
        protected MadnessEffect()
        {
        }

        protected MadnessEffect(MadnessEffect effect) : base(effect)
        {
        }

        public override bool CanBeApplied(IGameEvent gameEvent)
        {
            return gameEvent is CardMovedEvent e && e.Source == ZoneType.Hand && e.Destination == ZoneType.Graveyard && Source.Id == e.CardInSourceZone;
        }
    }

    class OptionalMadnessEffect : MadnessEffect
    {
        public OptionalMadnessEffect()
        {
        }

        public OptionalMadnessEffect(OptionalMadnessEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent)
        {
            if (Applier.ChooseToTakeAction(ToString()))
            {
                return new CardMovedEvent(gameEvent as ICardMovedEvent)
                {
                    Destination = ZoneType.BattleZone
                };
            }
            else
            {
                return gameEvent;
            }
        }

        public override IContinuousEffect Copy()
        {
            return new OptionalMadnessEffect(this);
        }

        public override string ToString()
        {
            return "When this creature would be discarded from your hand during your opponent's turn, you may put it into the battle zone instead.";
        }
    }
}
