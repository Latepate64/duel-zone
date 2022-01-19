using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class PutOwnShieldToGraveyardEffect : OneShotEffect
    {
        public PutOwnShieldToGraveyardEffect()
        {
        }

        public PutOwnShieldToGraveyardEffect(OneShotEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new PutOwnShieldToGraveyardEffect(this);
        }

        public override void Apply(Duel duel)
        {
            var controller = duel.GetPlayer(Controller);
            var shields = controller.ShieldZone.Cards;
            if (shields.Any())
            {
                var decision = controller.Choose(new GuidSelection(Controller, shields, 1, 1));
                duel.Move(duel.GetCard(decision.Decision.Single()), DuelMastersModels.Zones.ZoneType.ShieldZone, DuelMastersModels.Zones.ZoneType.Graveyard);
            }
        }
    }
}
