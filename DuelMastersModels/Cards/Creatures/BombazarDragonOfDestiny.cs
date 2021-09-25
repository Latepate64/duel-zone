using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Cards.Creatures
{
    public class BombazarDragonOfDestiny : Creature
    {
        public BombazarDragonOfDestiny() : base(7, new List<Civilization> { Civilization.Fire, Civilization.Nature }, 6000, new List<Race> { Race.ArmoredDragon, Race.EarthDragon })
        {
            TriggerAbilities.Add(new BombazarDragonOfDestinyAbility(Id));
            StaticAbilities.Add(new Abilities.StaticAbilities.SpeedAttacker(Id));
            StaticAbilities.Add(new Abilities.StaticAbilities.DoubleBreaker(Id));
        }

        public BombazarDragonOfDestiny(BombazarDragonOfDestiny x) : base(x) { }

        public override Card Copy()
        {
            return new BombazarDragonOfDestiny(this);
        }
    }

    internal class BombazarDragonOfDestinyAbility : TriggeredAbility
    {
        internal BombazarDragonOfDestinyAbility(System.Guid source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source) { }

        public override Choice Resolve(Duel duel, Decision choice)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            duel.Destroy(duel.BattleZoneCreatures.Where(c => c.Id != Source && c.Power == 6000));
            // then take an extra turn after this one.
            Turn turn = new Turn(Controller, duel.GetOpponent(Controller));
            duel.ExtraTurns.Enqueue(turn);
            // You lose the game at the end of the extra turn.
            duel.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new YouLoseTheGameAtTheEndOfTheExtraTurnAbility(Source, turn.Id), new Effects.Periods.Once(), Controller));
            return null;
        }

        public override Ability Copy()
        {
            return new BombazarDragonOfDestinyAbility(Source);
        }
    }

    internal class YouLoseTheGameAtTheEndOfTheExtraTurnAbility : TriggeredAbility
    {
        internal System.Guid Turn { get; }

        internal YouLoseTheGameAtTheEndOfTheExtraTurnAbility(System.Guid source, System.Guid turn) : base(new AtTheEndOfTurn(turn), source)
        {
            Turn = turn;
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
