using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class PalaOlesisMorningGuardian : Creature
    {
        public PalaOlesisMorningGuardian() : base("Pala Olesis, Morning Guardian", 3, 2500, Engine.Subtype.Guardian, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new PalaOlesisMorningGuardianEffect());
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }

    class PalaOlesisMorningGuardianEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public PalaOlesisMorningGuardianEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PalaOlesisMorningGuardianEffect();
        }

        public void ModifyPower(IGame game)
        {
            if (game.GetOpponent(GetController(game).Id) == game.CurrentTurn.ActivePlayer.Id)
            {
                game.BattleZone.GetCreatures(GetController(game).Id).Where(x => !IsSourceOfAbility(x, game)).ToList().ForEach(x => x.Power += 2000);
            }
        }

        public override string ToString()
        {
            return "During your opponent's turn, each of your other creatures gets +2000 power.";
        }
    }
}
