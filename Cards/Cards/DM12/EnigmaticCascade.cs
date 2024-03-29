﻿using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class EnigmaticCascade : Spell
    {
        public EnigmaticCascade() : base("Enigmatic Cascade", 4, Civilization.Water)
        {
            AddSpellAbilities(new EnigmaticCascadeEffect());
        }
    }

    class EnigmaticCascadeEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var player = Controller;
            int amount = player.DiscardAnyNumberOfCards(game, Ability);
            player.DrawCards(amount, game, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new EnigmaticCascadeEffect();
        }

        public override string ToString()
        {
            return "Discard any number of cards from your hand. Then draw that many cards.";
        }
    }
}
