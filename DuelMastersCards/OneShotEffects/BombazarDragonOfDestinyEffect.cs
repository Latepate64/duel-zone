using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Durations;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class BombazarDragonOfDestinyEffect : OneShotEffect
    {
        public BombazarDragonOfDestinyEffect() : base() { }

        public BombazarDragonOfDestinyEffect(BombazarDragonOfDestinyEffect effect) : base(effect)
        {
        }

        public override void Apply(Game game)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            game.Destroy(game.BattleZoneCreatures.Where(p => p.Id != Source && game.GetPower(p) == 6000).ToList());
            // then take an extra turn after this one.
            Turn turn = new Turn { ActivePlayer = Controller, NonActivePlayer = game.GetOpponent(Controller) };
            game.ExtraTurns.Enqueue(turn);
            // You lose the game at the end of the extra turn.
            game.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new AtTheEndOfTurnAbility(turn.Id, new YouLoseTheGameAtTheEndOfTheExtraTurnEffect()), new Once(), Source, Controller));
        }

        public override OneShotEffect Copy()
        {
            return new BombazarDragonOfDestinyEffect(this);
        }
    }

    public class YouLoseTheGameAtTheEndOfTheExtraTurnEffect : OneShotEffect
    {
        public YouLoseTheGameAtTheEndOfTheExtraTurnEffect() : base()
        {
        }

        public YouLoseTheGameAtTheEndOfTheExtraTurnEffect(YouLoseTheGameAtTheEndOfTheExtraTurnEffect effect) : base(effect)
        {
        }

        public override void Apply(Game game)
        {
            game.Lose(game.GetPlayer(Controller));
        }

        public override OneShotEffect Copy()
        {
            return new YouLoseTheGameAtTheEndOfTheExtraTurnEffect(this);
        }
    }
}
