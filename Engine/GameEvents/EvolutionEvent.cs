using System.Linq;
using Interfaces;

namespace Engine.GameEvents
{
    public sealed class EvolutionEvent(IPlayer player, ICard card, params ICard[] baits) : GameEvent
    {
        public IPlayer Player { get; } = player;
        public ICard EvolutionCreature { get; } = card;
        public ICard[] Baits { get; } = baits;

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
