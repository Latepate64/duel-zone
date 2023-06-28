using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.Cards.DM05
{
    class KipChippotto : Creature
    {
        public KipChippotto() : base("Kip Chippotto", 2, 1000, Race.FireBird, Civilization.Fire)
        {
            AddStaticAbilities(new KipChippottoEffect());
        }
    }

    class KipChippottoEffect : DestructionReplacementEffect
    {
        public KipChippottoEffect()
        {
        }

        public KipChippottoEffect(KipChippottoEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent)
        {
            if (Applier.ChooseToTakeAction(ToString()))
            {
                return new CardMovedEvent(gameEvent as ICardMovedEvent)
                {
                    CardInSourceZone = Source.Id
                };
            }
            else
            {
                return gameEvent;
            }
        }

        public override IContinuousEffect Copy()
        {
            return new KipChippottoEffect(this);
        }

        public override string ToString()
        {
            return "When one of your Armored Dragons would be destroyed, you may destroy this creature instead.";
        }

        protected override bool Applies(ICard card)
        {
            return card.Owner == Applier && card.HasRace(Race.ArmoredDragon);
        }
    }
}
