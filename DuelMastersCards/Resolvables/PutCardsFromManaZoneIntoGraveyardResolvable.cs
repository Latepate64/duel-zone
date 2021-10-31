using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class PutCardsFromManaZoneIntoGraveyardResolvable : Resolvable
    {
        public int Minimum { get; }

        public int Maximum { get; }

        public PutCardsFromManaZoneIntoGraveyardResolvable(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public PutCardsFromManaZoneIntoGraveyardResolvable(PutCardsFromManaZoneIntoGraveyardResolvable resolvable) : base(resolvable)
        {
            Minimum = resolvable.Minimum;
            Maximum = resolvable.Maximum;
        }

        public override Resolvable Copy()
        {
            return new PutCardsFromManaZoneIntoGraveyardResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                //TODO: Implement support for mana cards to be owned by either player.
                var cards = duel.GetPlayer(Controller).ManaZone.Cards;
                if (Minimum == Maximum)
                {
                    if (cards.Count <= Minimum)
                    {
                        return PutFromManaZoneIntoGraveyard(cards, duel);
                    }
                    else
                    {
                        return new GuidSelection(Controller, cards, Minimum, Maximum);
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                return PutFromManaZoneIntoGraveyard((decision as GuidDecision).Decision.Select(x => duel.GetCard(x)), duel);
            }
        }

        private Choice PutFromManaZoneIntoGraveyard(IEnumerable<Card> cards, Duel duel)
        {
            foreach (var card in cards)
            {
                duel.GetOwner(card).PutFromManaZoneIntoGraveyard(duel, card);
            }
            return null;
        }
    }
}
