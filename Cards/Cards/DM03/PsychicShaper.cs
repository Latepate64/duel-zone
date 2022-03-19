﻿using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM03
{
    class PsychicShaper : Spell
    {
        public PsychicShaper() : base("Psychic Shaper", 6, Civilization.Water)
        {
            AddAbilities(new SpellAbility(new PsychicShaperEffect()));
        }
    }

    class PsychicShaperEffect : OneShotEffect
    {
        public PsychicShaperEffect()
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Owner);
            var cards = player.RevealTopCardsOfDeck(4, game);
            game.Move(ZoneType.Deck, ZoneType.Hand, cards.Where(x => x.Civilizations.Contains(Civilization.Water)).ToArray());
            game.Move(ZoneType.Deck, ZoneType.Graveyard, cards.Where(x => !x.Civilizations.Contains(Civilization.Water)).ToArray());
            player.Unreveal(cards);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new PsychicShaperEffect();
        }

        public override string ToString()
        {
            return "Reveal the top 4 cards of your deck. Put all water cards from among them into your hand and the rest into your graveyard.";
        }
    }
}