using System.Linq;

namespace Engine.GameEvents
{
    public class EvolutionEvent(Player player, Card card, params Card[] baits) : GameEvent
    {
        public Player Player { get; } = player;
        public Card EvolutionCreature { get; } = card;
        public Card[] Baits { get; } = baits;

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
