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

        public BombazarDragonOfDestinyEffect(BombazarDragonOfDestinyEffect effect)
        {
        }

        public override void Apply(Game game, Ability source)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            game.Destroy(game.BattleZone.Creatures.Where(p => p.Id != source.Source && game.GetPower(p) == 6000).ToList());
            // then take an extra turn after this one.
            Turn turn = new() { ActivePlayer = source.Owner, NonActivePlayer = game.GetOpponent(source.Owner) };
            game.ExtraTurns.Push(turn);
            // You lose the game at the end of the extra turn.
            game.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new AtTheEndOfTurnAbility(turn.Id, new YouLoseTheGameAtTheEndOfTheExtraTurnEffect()), new Once(), source.Source, source.Owner));
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

        public YouLoseTheGameAtTheEndOfTheExtraTurnEffect(YouLoseTheGameAtTheEndOfTheExtraTurnEffect effect)
        {
        }

        public override void Apply(Game game, Ability source)
        {
            game.Lose(game.GetPlayer(source.Owner));
        }

        public override OneShotEffect Copy()
        {
            return new YouLoseTheGameAtTheEndOfTheExtraTurnEffect(this);
        }
    }
}
