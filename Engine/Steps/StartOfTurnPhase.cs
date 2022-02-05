using Common.GameEvents;
using System.Linq;

namespace Engine.Steps
{
    /// <summary>
    /// 501.1 The active player determines which cards they control will untap. Then they untap them all simultaneously. This is a turn-based action. Normally, all of a player’s cards untap, but effects can keep one or more of a player’s cards from untapping.
    /// </summary>
    public class StartOfTurnPhase : Phase, ITurnBasedActionable
    {
        public StartOfTurnPhase(bool skipDrawStep) : base(PhaseOrStep.StartOfTurn)
        {
            SkipDrawStep = skipDrawStep;
        }

        public override Phase GetNextPhase(Game game)
        {
            // 500.6. The player who plays first skips the draw step of their first turn.
            if (SkipDrawStep)
            {
                return new ChargePhase();
            }
            else
            {
                return new DrawPhase();
            }
        }

        /// <summary>
        /// 501.1 The active player determines which cards they control will untap. Then they untap them all simultaneously. This is a turn-based action. Normally, all of a player’s cards untap, but effects can keep one or more of a player’s cards from untapping.
        /// </summary>
        /// <returns></returns>
        public void PerformTurnBasedAction(Game game)
        {
            var player = game.GetPlayer(game.CurrentTurn.ActivePlayer.Id);
            foreach (var creature in game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer.Id))
            {
                creature.SummoningSickness = false;
            }
            player.Untap(game, game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer.Id).ToArray());
            player.Untap(game, player.ManaZone.Cards.ToArray());
        }

        internal bool SkipDrawStep { get; set; }

        public StartOfTurnPhase(StartOfTurnPhase step) : base(step)
        {
            SkipDrawStep = step.SkipDrawStep;
        }

        public override Phase Copy()
        {
            return new StartOfTurnPhase(this);
        }
    }
}
