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

        public override void Apply(Game game)
        {
            // You may choose a creature in the battle zone and return it to its owner's hand.
            var player = game.GetPlayer(Controller);
            var creatures = game.GetChoosableBattleZoneCreatures(player);
            if (creatures.Any())
            {
                var dec = player.Choose(new GuidSelection(Controller, creatures, 0, MaximumAmount));
                game.Move(dec.Decision.Select(x => game.GetCard(x)), DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Hand);
            }
        }
    }
}
