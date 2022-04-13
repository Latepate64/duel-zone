using Common;
using Common.Choices;
using Engine;
using Engine.GameEvents;

namespace Cards.ContinuousEffects
{
    abstract class DestructionReplacementOptionallyToHandEffect : DestructionReplacementEffect
    {
        public DestructionReplacementOptionallyToHandEffect() : base()
        {
        }

        public DestructionReplacementOptionallyToHandEffect(DestructionReplacementOptionallyToHandEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            if (GetController(game).Choose(new YesNoChoice(GetController(game).Id, ToString()), game).Decision)
            {
                return new CardMovedEvent(gameEvent as ICardMovedEvent)
                {
                    Destination = ZoneType.Hand
                };
            }
            else
            {
                return gameEvent;
            }
        }
    }
}
