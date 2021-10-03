﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    public class EmeralAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public EmeralAbility(EmeralAbility ability) : base(ability)
        {
            _firstPart = ability._firstPart;
        }

        public EmeralAbility() : base()
        {
        }

        public override Ability Copy()
        {
            return new EmeralAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            var controller = duel.GetPlayer(Controller);
            if (decision == null)
            {
                // You may add a card from your hand to your shields face down.
                if (controller.Hand.Cards.Any())
                {
                    return new GuidSelection(Controller, controller.Hand.Cards.Select(x => x.Id), 0, 1);
                }
                else
                {
                    return null;
                }
            }
            else if (_firstPart)
            {
                var cards = (decision as GuidDecision).Decision;
                if (cards.Any())
                {
                    controller.PutFromHandIntoShieldZone(duel.GetCard(cards.Single()), duel);

                    // If you do, choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
                    if (controller.ShieldZone.Cards.Any())
                    {
                        if (controller.ShieldZone.Cards.Count == 1)
                        {
                            controller.PutFromShieldZoneToHand(controller.ShieldZone.Cards.Single(), duel, false);
                            return null;
                        }
                        else
                        {
                            _firstPart = false;
                            return new GuidSelection(Controller, controller.ShieldZone.Cards.Select(x => x.Id), 1, 1);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            else
            {
                controller.PutFromShieldZoneToHand(duel.GetCard((decision as GuidDecision).Decision.Single()), duel, false);
                return null;
            }
        }

        private bool _firstPart = true;
    }
}
