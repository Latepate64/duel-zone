﻿using Common;
using Common.Choices;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class FunkyWizard : Creature
    {
        public FunkyWizard() : base("Funky Wizard", 4, 2000, Subtype.Merfolk, Civilization.Water)
        {
            AddBlockerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new FunkyWizardEffect());
        }
    }

    class FunkyWizardEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            foreach (var player in game.Players)
            {
                if (player.Choose(new YesNoChoice(player.Id, "You may draw a card."), game).Decision)
                {
                    player.DrawCards(1, game);
                }
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new FunkyWizardEffect();
        }

        public override string ToString()
        {
            return "Each player may draw a card.";
        }
    }
}