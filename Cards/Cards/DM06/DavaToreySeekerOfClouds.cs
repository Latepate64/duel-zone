using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.Cards.DM06
{
    class DavaToreySeekerOfClouds : Creature
    {
        public DavaToreySeekerOfClouds() : base("Dava Torey, Seeker of Clouds", 6, 5000, Race.MechaThunder, Civilization.Light)
        {
            AddStaticAbilities(new DavaToreyEffect());
        }
    }

    class DavaToreyEffect : MadnessEffect
    {
        public DavaToreyEffect()
        {
        }

        public DavaToreyEffect(DavaToreyEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.BattleZone
            };
        }

        public override IContinuousEffect Copy()
        {
            return new DavaToreyEffect(this);
        }

        public override string ToString()
        {
            return "During your opponent's turn, if this creature would be discarded from your hand, put it into the battle zone instead.";
        }
    }
}
