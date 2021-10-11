using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
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

        public override Choice Resolve(Duel duel, Decision decision)
        {
            var controller = duel.GetPlayer(Controller);
            if (decision == null)
            {
                var shields = controller.ShieldZone.Cards;
                if (shields.Count > 1)
                {
                    return new GuidSelection(Controller, shields, 1, 1);
                }
                else if (shields.Any())
                {
                    controller.PutFromShieldZoneToGraveyard(shields.Single(), duel);
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                controller.PutFromShieldZoneToGraveyard(duel.GetCard((decision as GuidDecision).Decision.Single()), duel);
                return null;
            }
        }
    }
}
