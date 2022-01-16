﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class EmeralResolvable : Resolvable
    {
        public EmeralResolvable(EmeralResolvable ability) : base(ability)
        {
            _firstPart = ability._firstPart;
        }

        public EmeralResolvable() : base()
        {
        }

        public override Resolvable Copy()
        {
            return new EmeralResolvable(this);
        }

        public override void Resolve(Duel duel, Decision decision)
        {
            var controller = duel.GetPlayer(Controller);
            if (decision == null)
            {
                // You may add a card from your hand to your shields face down.
                if (controller.Hand.Cards.Any())
                {
                    duel.SetAwaitingChoice(new GuidSelection(Controller, controller.Hand.Cards, 0, 1));
                }
  
            }
            else if (_firstPart)
            {
                PutFromHandIntoShieldZone(duel, decision, controller);
            }
            else
            {
                duel.PutFromShieldZoneToHand(duel.GetCard((decision as GuidDecision).Decision.Single()), false);
            }
        }

        private void PutFromHandIntoShieldZone(Duel duel, Decision decision, Player controller)
        {
            var cards = (decision as GuidDecision).Decision;
            if (cards.Any())
            {
                duel.Move(cards.Select(x => duel.GetCard(x)), DuelMastersModels.Zones.ZoneType.Hand, DuelMastersModels.Zones.ZoneType.ShieldZone);

                // If you do, choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
                if (controller.ShieldZone.Cards.Any())
                {
                    if (controller.ShieldZone.Cards.Count == 1)
                    {
                        duel.PutFromShieldZoneToHand(controller.ShieldZone.Cards.Single(), false);
                    }
                    else
                    {
                        _firstPart = false;
                        duel.SetAwaitingChoice(new GuidSelection(Controller, controller.ShieldZone.Cards, 1, 1));
                    }
                }
            }
        }

        private bool _firstPart = true;
    }
}
