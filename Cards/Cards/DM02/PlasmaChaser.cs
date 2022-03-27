﻿using Common;
using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM02
{
    class PlasmaChaser : Creature
    {
        public PlasmaChaser() : base("Plasma Chaser", 6, 4000, Subtype.GelFish, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new PlasmaChaserEffect()));
        }
    }

    class PlasmaChaserEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.GetOpponent(game).Id).Count();
            if (amount > 0 && source.GetController(game).Choose(new YesNoChoice(source.Controller, $"You may draw {amount} cards."), game).Decision)
            {
                source.GetController(game).DrawCards(amount, game);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new PlasmaChaserEffect();
        }

        public override string ToString()
        {
            return "You may draw a number of cards equal to the number of creatures your opponent has in the battle zone.";
        }
    }
}
