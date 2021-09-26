using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Cards.Creatures
{
    public class BombazarDragonOfDestiny : Creature
    {
        public BombazarDragonOfDestiny(Guid owner) : base(owner, 7, new List<Civilization> { Civilization.Fire, Civilization.Nature }, 6000, new List<Race> { Race.ArmoredDragon, Race.EarthDragon })
        {
            TriggeredAbilities.Add(new BombazarDragonOfDestinyAbility(Id, owner));
            StaticAbilities.Add(new Abilities.StaticAbilities.SpeedAttacker(Id, owner));
            StaticAbilities.Add(new Abilities.StaticAbilities.DoubleBreaker(Id, owner));
        }

        public BombazarDragonOfDestiny(BombazarDragonOfDestiny x) : base(x) { }

        public override Card Copy()
        {
            return new BombazarDragonOfDestiny(this);
        }
    }

    internal class BombazarDragonOfDestinyAbility : WhenYouPutThisCreatureIntoTheBattleZone
    {
        internal BombazarDragonOfDestinyAbility(Guid source, Guid controller) : base(source, controller) { }

        public BombazarDragonOfDestinyAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override Choice Resolve(Duel duel, Decision choice)
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

        public override NonStaticAbility Copy()
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

        public override NonStaticAbility Copy()
        {
            return new YouLoseTheGameAtTheEndOfTheExtraTurnAbility(this);
        }
    }
}
