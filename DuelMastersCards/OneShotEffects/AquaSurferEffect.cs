using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class AquaSurferEffect : OneShotEffect
    {
        public int MaximumAmount { get; }

        public AquaSurferEffect(int maximumAmount) : base()
        {
            MaximumAmount = maximumAmount;
        }

        public AquaSurferEffect(AquaSurferEffect effect) : base(effect)
        {
            MaximumAmount = effect.MaximumAmount;
        }

        public override OneShotEffect Copy()
        {
            return new AquaSurferEffect(this);
        }

        public override void Apply(Duel duel)
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
