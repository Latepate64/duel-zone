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
            //StaticAbilities.Add(new Abilities.StaticAbilities.DoubleBreaker(this)); //TODO: Implement
        }
    }

    internal class BombazarDragonOfDestinyAbility : TriggeredAbility
    {
        internal BombazarDragonOfDestinyAbility(Card source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source) { }

        public override Choice Resolve(Duel duel, Choice choice)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            duel.Destroy(duel.BattleZone.Creatures.Where(c => c != Source && c.Power == 6000));
            // then take an extra turn after this one.
            Turn turn = new Turn(Controller, duel.CurrentTurn.Number+1); //TODO: Turn number should not be updated in constructor.
            duel.ExtraTurns.Enqueue(turn);
            // You lose the game at the end of the extra turn.
            duel.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new YouLoseTheGameAtTheEndOfTheExtraTurnAbility(Source, turn), new Effects.Periods.Once()));
            return null;
        }

        public override NonStaticAbility Copy()
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

        public override NonStaticAbility Copy()
        {
            return new YouLoseTheGameAtTheEndOfTheExtraTurnAbility(Source, Turn);
        }

        public override Choice Resolve(Duel duel, Choice choice)
        {
            throw new System.NotImplementedException();
        }
    }
}
