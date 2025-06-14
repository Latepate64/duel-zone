using System.Linq;

namespace Engine.GameEvents
{
    public class EvolutionEvent : GameEvent
    {
        public EvolutionEvent(IPlayer player, Card card, params Card[] baits)
        {
            Player = player;
            EvolutionCreature = card;
            Baits = baits;
        }

        public IPlayer Player { get; }
        public Card EvolutionCreature { get; }
        public Card[] Baits { get; }

        public override void Happen(IGame game)
        {
            EvolutionCreature.PutOnTopOf(Baits);
        }

        public override string ToString()
        {
            var baitText = string.Join(" and ", Baits.Select(x => x.Name));
            return $"{Player} evolved {baitText} into {EvolutionCreature}.";
        }
    }
}
