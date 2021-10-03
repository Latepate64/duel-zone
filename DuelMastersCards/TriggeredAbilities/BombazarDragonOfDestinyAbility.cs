using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.Effects.Durations;
using System;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    public class BombazarDragonOfDestinyAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public BombazarDragonOfDestinyAbility() : base() { }

        public BombazarDragonOfDestinyAbility(BombazarDragonOfDestinyAbility ability) : base(ability)
        {
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            duel.Destroy(duel.CreaturePermanents.Where(p => p.Id != Source && duel.GetPower(p) == 6000));
            // then take an extra turn after this one.
            Turn turn = new Turn { ActivePlayer = Controller, NonActivePlayer = duel.GetOpponent(Controller) };
            duel.ExtraTurns.Enqueue(turn);
            // You lose the game at the end of the extra turn.
            duel.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new YouLoseTheGameAtTheEndOfTheExtraTurnAbility(turn.Id), new Once(), Source, Controller));
            return null;
        }

        public override Ability Copy()
        {
            return new BombazarDragonOfDestinyAbility(this);
        }
    }

    internal class YouLoseTheGameAtTheEndOfTheExtraTurnAbility : AtTheEndOfTurnAbility
    {
        internal YouLoseTheGameAtTheEndOfTheExtraTurnAbility(Guid turn) : base(turn)
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
