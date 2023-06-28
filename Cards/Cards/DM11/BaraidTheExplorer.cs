using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class BaraidTheExplorer : SilentSkillCreature
    {
        public BaraidTheExplorer() : base("Baraid, the Explorer", 5, 5000, Race.Gladiator, Civilization.Light)
        {
            AddSilentSkillAbility(new BaraidTheExplorerEffect());
        }
    }

    class BaraidTheExplorerEffect : OneShotEffect
    {
        public BaraidTheExplorerEffect() : base()
        {
        }

        public override void Apply()
        {
            Game.AddContinuousEffects(Ability, new YourLightCreaturesCannotBeBlockedThisTurnEffect());
        }

        public override IOneShotEffect Copy()
        {
            return new BaraidTheExplorerEffect();
        }

        public override string ToString()
        {
            return "Your light creatures can't be blocked this turn.";
        }
    }

    class YourLightCreaturesCannotBeBlockedThisTurnEffect : ContinuousEffects.UntilEndOfTurnEffect, IUnblockableEffect
    {
        public YourLightCreaturesCannotBeBlockedThisTurnEffect() : base()
        {
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return game.BattleZone.GetCreatures(Applier).Contains(attacker) && attacker.HasCivilization(Civilization.Light);
        }

        public override IContinuousEffect Copy()
        {
            return new YourLightCreaturesCannotBeBlockedThisTurnEffect();
        }

        public override string ToString()
        {
            return "Your light creatures can't be blocked this turn.";
        }
    }
}
