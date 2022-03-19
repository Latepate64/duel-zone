using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;
using Engine.Durations;
using System.Linq;

namespace Cards.Cards.DM10
{
    class BombazarDragonOfDestiny : Creature
    {
        public BombazarDragonOfDestiny() : base("Bombazar, Dragon of Destiny", 7, 6000, Civilization.Fire, Civilization.Nature)
        {
            AddSubtypes(Subtype.ArmoredDragon, Subtype.EarthDragon);
            // When you put this creature into the battle zone, destroy all other creatures that have 6000 power. Take an extra turn after this one. You lose the game at the end of that turn.
            AddAbilities(new SpeedAttackerAbility(), new DoubleBreakerAbility(), new PutIntoPlayAbility(new BombazarDragonOfDestinyEffect()));
        }
    }

    class BombazarDragonOfDestinyEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            game.Destroy(game.BattleZone.Creatures.Where(p => p.Id != source.Source && p.Power.Value == 6000).ToList());
            // then take an extra turn after this one.
            var owner = game.GetPlayer(source.Owner);
            Engine.Turn turn = new() { ActivePlayer = owner, NonActivePlayer = game.GetOpponent(owner) };
            game.ExtraTurns.Push(turn);
            // You lose the game at the end of the extra turn.
            game.AddDelayedTriggeredAbility(new AtTheEndOfTurnAbility(turn.Id, new YouLoseTheGameAtTheEndOfTheExtraTurnEffect()), new Once());
            return true;
        }

        public override OneShotEffect Copy()
        {
            return new BombazarDragonOfDestinyEffect();
        }

        public override string ToString()
        {
            return "Destroy all other creatures that have power 6000, then take an extra turn after this one. You lose the game at the end of the extra turn.";
        }
    }

    class YouLoseTheGameAtTheEndOfTheExtraTurnEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.Lose(game.GetPlayer(source.Owner));
            return true;
        }

        public override OneShotEffect Copy()
        {
            return new YouLoseTheGameAtTheEndOfTheExtraTurnEffect();
        }

        public override string ToString()
        {
            return "You lose the game.";
        }
    }
}
