using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class PutOwnShieldToGraveyardResolvable : Resolvable
    {
        public PutOwnShieldToGraveyardResolvable()
        {
        }

        public PutOwnShieldToGraveyardResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new PutOwnShieldToGraveyardResolvable(this);
        }

        public override void Resolve(Duel duel)
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
