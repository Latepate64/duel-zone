using Common.GameEvents;
using Engine;

namespace Cards.Durations
{
    public class Indefinite : Duration
    {
        public override IDuration Copy()
        {
            return new Indefinite();
        }

        public override bool ShouldExpire(IGameEvent gameEvent)
        {
            return false;
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
