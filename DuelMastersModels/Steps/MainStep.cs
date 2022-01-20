﻿using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 504.1. Normally, the active player can use cards only during their main step.
    /// </summary>
    public class MainStep : PriorityStep
    {
        public MainStep()
        {
        }

        protected internal override bool PerformPriorityAction(Game game)
        {
            var player = game.GetPlayer(game.CurrentTurn.ActivePlayer);
            var usableCards = player.GetUsableCardsWithPaymentInformation();
            if (usableCards.Any())
            {
                var dec = player.Choose(new CardUsageChoice(game.CurrentTurn.ActivePlayer, usableCards));
                if (dec.Decision == null)
                {
                    return true;
                }
                else
                {
                    foreach (Card mana in dec.Decision.Manas.Select(x => game.GetCard(x)))
                    {
                        mana.Tapped = true;
                    }
                    game.UseCard(game.GetCard(dec.Decision.ToUse), game.GetPlayer(game.CurrentTurn.ActivePlayer));
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public override Step GetNextStep(Game game)
        {
            return new AttackDeclarationStep();
        }

        public MainStep(MainStep step) : base(step) { }

        public override Step Copy()
        {
            return new MainStep(this);
        }
    }
}
