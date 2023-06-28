using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Linq;

namespace Cards.Cards.DM09
{
    class KaluteVizierOfEternity : Creature
    {
        public KaluteVizierOfEternity() : base("Kalute, Vizier of Eternity", 2, 1000, Race.Initiate, Civilization.Light)
        {
            AddStaticAbilities(new KaluteEffect());
        }
    }

    class KaluteEffect : DestructionReplacementEffect
    {
        public KaluteEffect()
        {
        }

        public KaluteEffect(KaluteEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.Hand
            };
        }

        public override IContinuousEffect Copy()
        {
            return new KaluteEffect(this);
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, if another Kalute, Vizier of Eternity is in the battle zone, return this creature to your hand instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return IsSourceOfAbility(card) && game.BattleZone.GetOtherCreatures(card).Any(x => x.Name == "Kalute, Vizier of Eternity");
        }
    }
}
