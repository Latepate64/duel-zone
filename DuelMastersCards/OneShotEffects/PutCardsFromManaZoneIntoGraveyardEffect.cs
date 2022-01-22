using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public enum ZoneOwner { Controller, Opponent }

    public class PutCardsFromManaZoneIntoGraveyardEffect : OneShotEffect
    {
        public int Minimum { get; }

        public int Maximum { get; }

        public ZoneOwner ZoneOwner { get; }

        public PutCardsFromManaZoneIntoGraveyardEffect(int minimum, int maximum, ZoneOwner zoneOwner)
        {
            Minimum = minimum;
            Maximum = maximum;
            ZoneOwner = zoneOwner;
        }

        public PutCardsFromManaZoneIntoGraveyardEffect(PutCardsFromManaZoneIntoGraveyardEffect effect)
        {
            Minimum = effect.Minimum;
            Maximum = effect.Maximum;
            ZoneOwner = effect.ZoneOwner;
        }

        public override OneShotEffect Copy()
        {
            return new PutCardsFromManaZoneIntoGraveyardEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            var player = GetPlayer(game, source.Owner);
            var cards = player.ManaZone.Cards;
            if (Minimum == Maximum)
            {
                if (cards.Count <= Minimum)
                {
                    PutFromManaZoneIntoGraveyard(cards, game);
                }
                else
                {
                    var decision = player.Choose(new GuidSelection(source.Owner, cards, Minimum, Maximum));
                    PutFromManaZoneIntoGraveyard(decision.Decision.Select(x => game.GetCard(x)), game);
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void PutFromManaZoneIntoGraveyard(IEnumerable<Card> cards, Game game)
        {
            game.Move(cards, DuelMastersModels.Zones.ZoneType.ManaZone, DuelMastersModels.Zones.ZoneType.Graveyard);
        }

        private Player GetPlayer(Game game, Guid owner)
        {
            var controller = game.GetPlayer(owner);
            if (ZoneOwner == ZoneOwner.Controller)
            {
                return controller;
            }
            else if (ZoneOwner == ZoneOwner.Opponent)
            {
                return game.GetOpponent(controller);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
