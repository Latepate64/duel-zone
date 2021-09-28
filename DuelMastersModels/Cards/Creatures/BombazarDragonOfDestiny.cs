using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersModels.Cards.Creatures
{
    public class BombazarDragonOfDestinyAbility : WhenYouPutThisCreatureIntoTheBattleZone
    {
        public BombazarDragonOfDestinyAbility(Guid source, Guid controller) : base(source, controller) { }

        public BombazarDragonOfDestinyAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            duel.Destroy(duel.BattleZoneCreatures.Where(c => c.Id != Source && c.Power == 6000));
            // then take an extra turn after this one.
            Turn turn = new Turn(Controller, duel.GetOpponent(Controller));
            duel.ExtraTurns.Enqueue(turn);
            // You lose the game at the end of the extra turn.
            duel.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new YouLoseTheGameAtTheEndOfTheExtraTurnAbility(Source, Controller, turn.Id), new Effects.Periods.Once(), Controller));
            return null;
        }

        public override Ability Copy()
        {
            return new BombazarDragonOfDestinyAbility(this);
        }
    }

    internal class YouLoseTheGameAtTheEndOfTheExtraTurnAbility : AtTheEndOfTurn
    {
        internal YouLoseTheGameAtTheEndOfTheExtraTurnAbility(Guid source, Guid controller, Guid turn) : base(source, controller, turn)
        {
        }

        public YouLoseTheGameAtTheEndOfTheExtraTurnAbility(YouLoseTheGameAtTheEndOfTheExtraTurnAbility ability) : base(ability)
        {
        }

        public override Choice Resolve(Duel duel, Decision choice)
        {
            var gameOver = new GameOver(WinReason.Bombazar, duel.Players.Select(x => x.Id).Where(p => p != Controller), duel.Players.Select(x => x.Id).Where(p => p == Controller));
            duel.GameOverInformation = gameOver;
            duel.State = DuelState.Over;
            return gameOver;
        }

        public override Ability Copy()
        {
            return new YouLoseTheGameAtTheEndOfTheExtraTurnAbility(this);
        }
    }
}
