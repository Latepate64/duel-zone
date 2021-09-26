using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersModels.Cards.Creatures
{
    public class Emeral : Creature
    {
        public Emeral(Guid owner) : base(owner, 2, Civilization.Water, 1000, Race.CyberLord)
        {
            TriggeredAbilities.Add(new EmeralAbility(Id, owner));
        }

        public Emeral(Creature creature) : base(creature)
        {
        }

        public override Card Copy()
        {
            return new Emeral(this);
        }
    }

    public class EmeralAbility : WhenYouPutThisCreatureIntoTheBattleZone
    {
        public EmeralAbility(EmeralAbility ability) : base(ability)
        {
            _firstPart = ability._firstPart;
        }

        public EmeralAbility(Guid source, Guid controller) : base(source, controller)
        {
        }

        public override NonStaticAbility Copy()
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
                    return new Selection<Guid>(Controller, controller.Hand.Cards.Select(x => x.Id));
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
                        if (controller.ShieldZone.Cards.Count() == 1)
                        {
                            controller.PutFromShieldZoneToHand(controller.ShieldZone.Cards.Single(), duel, false);
                            return null;
                        }
                        else
                        {
                            _firstPart = false;
                            return new Selection<Guid>(Controller, controller.ShieldZone.Cards.Select(x => x.Id), 1, 1);
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
