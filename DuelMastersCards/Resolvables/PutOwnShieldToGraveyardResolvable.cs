﻿using DuelMastersModels;
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
                    duel.Move(shields.Single(), DuelMastersModels.Zones.ZoneType.ShieldZone, DuelMastersModels.Zones.ZoneType.Graveyard);
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                duel.Move(duel.GetCard((decision as GuidDecision).Decision.Single()), DuelMastersModels.Zones.ZoneType.ShieldZone, DuelMastersModels.Zones.ZoneType.Graveyard);
                return null;
            }
        }
    }
}
