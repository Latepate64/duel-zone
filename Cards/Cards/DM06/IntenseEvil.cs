﻿using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM06
{
    class IntenseEvil : Spell
    {
        public IntenseEvil() : base("Intense Evil", 3, Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new IntenseEvilEffect());
        }
    }

    class IntenseEvilEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var player = Controller;
            var cards = player.ChooseAnyNumberOfCards(game.BattleZone.GetCreatures(player.Id), ToString()).ToArray();
            game.Move(Ability, ZoneType.BattleZone, ZoneType.Graveyard, cards);
            player.DrawCards(cards.Length, game, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new IntenseEvilEffect();
        }

        public override string ToString()
        {
            return "Destroy any number of your creatures. Then draw that many cards.";
        }
    }
}
