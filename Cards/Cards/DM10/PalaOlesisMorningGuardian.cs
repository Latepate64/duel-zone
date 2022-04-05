﻿using Cards.CardFilters;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class PalaOlesisMorningGuardian : Creature
    {
        public PalaOlesisMorningGuardian() : base("Pala Olesis, Morning Guardian", 3, 2500, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new PalaOlesisMorningGuardianEffect());
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }

    class PalaOlesisMorningGuardianEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public PalaOlesisMorningGuardianEffect() : base(new OwnersOtherBattleZoneCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PalaOlesisMorningGuardianEffect();
        }

        public void ModifyPower(IGame game)
        {
            if (game.GetOpponent(game.GetAbility(SourceAbility).Controller) == game.CurrentTurn.ActivePlayer.Id)
            {
                GetAffectedCards(game).ToList().ForEach(x => x.Power += 2000);
            }
        }

        public override string ToString()
        {
            return "During your opponent's turn, each of your other creatures gets +2000 power.";
        }
    }
}
