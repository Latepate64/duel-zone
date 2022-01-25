using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class EmeralEffect : OneShotEffect
    {
        public EmeralEffect(EmeralEffect effect)
        {
        }

        public EmeralEffect() : base()
        {
        }

        public override OneShotEffect Copy()
        {
            return new EmeralEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            // You may add a card from your hand to your shields face down.
            var controller = game.GetPlayer(source.Owner);
            if (controller.Hand.Cards.Any())
            {
                var decision = controller.Choose(new GuidSelection(source.Owner, controller.Hand.Cards, 0, 1));
                var cards = (decision as GuidDecision).Decision;
                if (cards.Any())
                {
                    game.Move(cards.Select(x => game.GetCard(x)), DuelMastersModels.Zones.ZoneType.Hand, DuelMastersModels.Zones.ZoneType.ShieldZone);

                    // If you do, choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
                    new ShieldRecoveryEffect(new CardFilters.OwnersShieldZoneCardFilter(), 1, 1, true, false).Apply(game, source);
                }
            }
        }
    }
}
