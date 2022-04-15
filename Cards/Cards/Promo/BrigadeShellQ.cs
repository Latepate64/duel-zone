﻿using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.Promo
{
    class BrigadeShellQ : Creature
    {
        public BrigadeShellQ() : base("Brigade Shell Q", 3, 1000, Engine.Subtype.Survivor, Engine.Subtype.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddSurvivorAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new BrigadeShellQEffect()));
        }
    }

    class BrigadeShellQEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = source.GetController(game).RevealTopCardsOfDeck(1, game).ToArray();
            if (cards.Length == 1)
            {
                if (cards.Single().HasSubtype(Engine.Subtype.Survivor))
                {
                    game.Move(ZoneType.Deck, ZoneType.Hand, cards);
                }
                else
                {
                    game.Move(ZoneType.Deck, ZoneType.Graveyard, cards);
                }
            }
            source.GetController(game).Unreveal(cards);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new BrigadeShellQEffect();
        }

        public override string ToString()
        {
            return "Reveal the top card of your deck. If it's a Survivor, put it into your hand. Otherwise, put it into your graveyard.";
        }
    }
}
