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
            TriggerAbilities.Add(new BombazarDragonOfDestinyAbility(this));
            StaticAbilities.Add(new Abilities.StaticAbilities.SpeedAttacker(this));
            StaticAbilities.Add(new Abilities.StaticAbilities.DoubleBreaker(this));
        }

        public BombazarDragonOfDestiny(BombazarDragonOfDestiny x) : base(x) { }

        public override Card Copy()
        {
            return new BombazarDragonOfDestiny(this);
        }
    }

    internal class BombazarDragonOfDestinyAbility : TriggeredAbility
    {
        internal BombazarDragonOfDestinyAbility(Card source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source) { }

        public override Choice Resolve(Duel duel, Decision choice)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            duel.Destroy(duel.BattleZoneCreatures.Where(c => c != Source && c.Power == 6000));
            // then take an extra turn after this one.
            Turn turn = new Turn(Controller, duel.GetOpponent(Controller));
            duel.ExtraTurns.Enqueue(turn);
            // You lose the game at the end of the extra turn.
            duel.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new YouLoseTheGameAtTheEndOfTheExtraTurnAbility(Source, turn), new Effects.Periods.Once()));
            return null;
        }

        public override Ability Copy()
        {
            return new BombazarDragonOfDestinyAbility(Source);
        }
    }

    internal class YouLoseTheGameAtTheEndOfTheExtraTurnAbility : TriggeredAbility
    {
        internal Turn Turn { get; }

        internal YouLoseTheGameAtTheEndOfTheExtraTurnAbility(Card source, Turn turn) : base(new AtTheEndOfTurn(turn), source)
        {
            Turn = turn;
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
            return Copy(new YouLoseTheGameAtTheEndOfTheExtraTurnAbility(Source, Turn));
        }
    }

    public class GontaTheWarriorSavage : Creature
    {
        public GontaTheWarriorSavage() : base(2, new List<Civilization> { Civilization.Fire, Civilization.Nature }, 4000, new List<Race> { Race.Human, Race.BeastFolk })
        {
        }

        public GontaTheWarriorSavage(GontaTheWarriorSavage x) : base(x) { }

        public override Card Copy()
        {
            return new GontaTheWarriorSavage(this);
        }
    }

    public class WindAxeTheWarriorSavage : Creature
    {
        public WindAxeTheWarriorSavage() : base(5, new List<Civilization> { Civilization.Fire, Civilization.Nature }, 2000, new List<Race> { Race.Human, Race.BeastFolk })
        {
            TriggerAbilities.Add(new WindAxeTheWarriorSavageAbility(this));
        }

        public WindAxeTheWarriorSavage(WindAxeTheWarriorSavage x) : base(x) { }

        public override Card Copy()
        {
            return new WindAxeTheWarriorSavage(this);
        }
    }

    internal class WindAxeTheWarriorSavageAbility : TriggeredAbility
    {
        internal WindAxeTheWarriorSavageAbility(Card source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source)
        {
        }

        public override Ability Copy()
        {
            return Copy(new WindAxeTheWarriorSavageAbility(Source));
        }

        public override Choice Resolve(Duel duel, Decision choice)
        {
            throw new System.NotImplementedException();
            //// When you put this creature into the battle zone, destroy one of your opponent's creatures that has "blocker."
            //if (choice == null)
            //{

            //}
            //Creature creature;// = choice as Choice
            //duel.Destroy(creature);
            //// Then put the top card of your deck into your mana zone.
            //Controller.PutFromTopOfDeckIntoManaZone();
            //return null;
        }
    }
}
