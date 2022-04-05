using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class BaraidTheExplorer : SilentSkillCreature
    {
        public BaraidTheExplorer() : base("Baraid, the Explorer", 5, 5000, Common.Subtype.Gladiator, Common.Civilization.Light)
        {
            AddSilentSkillAbility(new BaraidTheExplorerEffect());
        }
    }

    class BaraidTheExplorerEffect : OneShotEffect
    {
        public BaraidTheExplorerEffect() : base()
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new YourLightCreaturesCannotBeBlockedThisTurnEffect());
            return null;
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
        public YourLightCreaturesCannotBeBlockedThisTurnEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Common.Civilization.Light))
        {
        }

        public bool Applies(ICard blocker, IGame game)
        {
            return true;
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
