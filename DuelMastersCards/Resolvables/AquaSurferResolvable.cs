using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class AquaSurferResolvable : Resolvable
    {
        public int MaximumAmount { get; }

        public AquaSurferResolvable(int maximumAmount) : base()
        {
            MaximumAmount = maximumAmount;
        }

        public AquaSurferResolvable(AquaSurferResolvable ability) : base(ability)
        {
            MaximumAmount = ability.MaximumAmount;
        }

        public override Resolvable Copy()
        {
            return new AquaSurferResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            // You may choose a creature in the battle zone and return it to its owner's hand.
            var player = duel.GetPlayer(Controller);
            var creatures = duel.GetChoosableCreaturePermanents(player);
            if (creatures.Any())
            {
                var dec = player.Choose(new GuidSelection(Controller, creatures, 0, MaximumAmount));
                duel.Move(dec.Decision.Select(x => duel.GetPermanent(x)), DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Hand);
            }
        }
    }
}
