//using DuelMastersModels.Cards;
using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using System;
//using System.Collections.Generic;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargeStep : Step
    {
        public IHandCard ChargedCard { get; set; }

        public ChargeStep(IPlayer player) : base(player)
        {
        }

        public IChoice ChargeMana(IHandCard card)
        {
            if (ChargedCard != null)
            {
                throw new InvalidOperationException("Mana has already been charged during this step.");
            }
            else if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            ActivePlayer.PutFromHandIntoManaZone(card);
            ChargedCard = card;
            return Proceed();
        }

        public override IStep GetNextStep()
        {
            return new MainStep(ActivePlayer);
        }

        public override (IChoice, bool) PerformPriorityAction()
        {
            State = StepState.PriorityAction;
            if (ChargedCard != null)
            {
                return (null, false);
            }
            else
            {
                throw new NotImplementedException();
                //IEnumerable<IHandCard> usableCards = MainStep.GetUsableCards(ActivePlayer.Hand.Cards, ActivePlayer.ManaZone.UntappedCards);
                //return new PriorityActionChoice(ActivePlayer, ActivePlayer.Hand.Cards, usableCards, duel.GetCreaturesThatCanAttack(ActivePlayer));
            }
        }

        //TODO
        //public override IChoice PlayerActionRequired(IDuel duel)
        //{
        //    if (MustBeEnded || !ActivePlayer.Hand.Cards.Any())
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        MustBeEnded = true;
        //        IEnumerable<IHandCard> usableCards = MainStep.GetUsableCards(ActivePlayer.Hand.Cards, ActivePlayer.ManaZone.UntappedCards);
        //        return new PriorityActionRequest(ActivePlayer, ActivePlayer.Hand.Cards, usableCards, duel.GetCreaturesThatCanAttack(ActivePlayer));
        //    }
        //}
    }
}
