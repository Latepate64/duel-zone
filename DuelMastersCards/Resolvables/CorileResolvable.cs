using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class CorileResolvable : Resolvable
    {
        public CorileResolvable()
        {
        }

        public CorileResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new CorileResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            // Choose one of your opponent's creatures in the battle zone and put it on top of his deck.
            var player = duel.GetPlayer(Controller);
            var opponent = duel.GetOpponent(player);
            var choosable = opponent.BattleZone.GetChoosableCreatures(duel);
            if (choosable.Any())
            {
                var dec = player.Choose(new GuidSelection(Controller, choosable, 1, 1));
                opponent.PutFromBattleZoneOnTopOfDeck(duel.GetPermanent(dec.Decision.Single()), duel);
            }
        }
    }
}
