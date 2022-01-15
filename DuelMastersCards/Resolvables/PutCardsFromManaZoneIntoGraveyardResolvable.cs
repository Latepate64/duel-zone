using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public enum ZoneOwner { Controller, Opponent }

    public class PutCardsFromManaZoneIntoGraveyardResolvable : Resolvable
    {
        public int Minimum { get; }

        public int Maximum { get; }

        public ZoneOwner ZoneOwner { get; }

        public PutCardsFromManaZoneIntoGraveyardResolvable(int minimum, int maximum, ZoneOwner zoneOwner)
        {
            Minimum = minimum;
            Maximum = maximum;
            ZoneOwner = zoneOwner;
        }

        public PutCardsFromManaZoneIntoGraveyardResolvable(PutCardsFromManaZoneIntoGraveyardResolvable resolvable) : base(resolvable)
        {
            Minimum = resolvable.Minimum;
            Maximum = resolvable.Maximum;
            ZoneOwner = resolvable.ZoneOwner;
        }

        public override Resolvable Copy()
        {
            return new PutCardsFromManaZoneIntoGraveyardResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                var cards = GetPlayer(duel).ManaZone.Cards;
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
                var player = duel.GetOwner(card);
                duel.Move(card, player.ManaZone, player.Graveyard);
            }
            return null;
        }

        private Player GetPlayer(Duel duel)
        {
            var controller = duel.GetPlayer(Controller);
            if (ZoneOwner == ZoneOwner.Controller)
            {
                return controller;
            }
            else if (ZoneOwner == ZoneOwner.Opponent)
            {
                return duel.GetOpponent(controller);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
