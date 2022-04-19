﻿using Engine;
using Engine.Abilities;
using System.Collections.Generic;
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
        public override void Apply(IGame game, IAbility source)
        {
            var player = source.GetController(game);
            var cards = player.ChooseAnyNumberOfCards(game.BattleZone.GetCreatures(player.Id), ToString());
            new OneShotEffects.DrawCardsEffect(cards.Count()).Apply(game, source);
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

    class DestroyAnyNumberOfYourCreatures : OneShotEffects.ChooseAnyNumberOfCardsEffect
    {
        public DestroyAnyNumberOfYourCreatures() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyAnyNumberOfYourCreatures();
        }

        public override string ToString()
        {
            return "Destroy any number of your creatures.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.Move(source, ZoneType.BattleZone, ZoneType.Graveyard, cards);
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }
}
