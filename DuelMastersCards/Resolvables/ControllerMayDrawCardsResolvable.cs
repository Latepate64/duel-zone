﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.Resolvables
{
    public class ControllerMayDrawCardsResolvable : Resolvable
    {
        public int Maximum { get; }

        private int _drawn;

        public ControllerMayDrawCardsResolvable(int maximum) : base()
        {
            Maximum = maximum;
        }

        public ControllerMayDrawCardsResolvable(ControllerMayDrawCardsResolvable ability) : base(ability)
        {
            Maximum = ability.Maximum;
        }

        public override Resolvable Copy()
        {
            return new ControllerMayDrawCardsResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                return new YesNoChoice(Controller);
            }
            else if ((decision as YesNoDecision).Decision)
            {
                duel.GetPlayer(Controller).DrawCards(1, duel);
                if (++_drawn < Maximum)
                {
                    return Resolve(duel, null);
                }
            }
            return null;
        }
    }
}