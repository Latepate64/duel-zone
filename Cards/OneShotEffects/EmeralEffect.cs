using Common;
using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;

namespace Cards.OneShotEffects
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
            var controller = game.GetPlayer(source.Owner);
            if (controller.Hand.Cards.Any())
            {
                var decision = controller.Choose(new BoundedCardSelectionInEffect(source.Owner, controller.Hand.Cards, 0, 1, "You may add a card from your hand to your shields face down."), game);
                var cards = decision.Decision;
                if (cards.Any())
                {
                    game.Move(ZoneType.Hand, ZoneType.ShieldZone, cards.Select(x => game.GetCard(x)).ToArray());

                    // If you do, choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
                    new ShieldRecoveryEffect(false).Apply(game, source);
                }
            }
        }

        public override string ToString()
        {
            return "You may add a card from your hand to your shields face down. If you do, choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
        }
    }
}
