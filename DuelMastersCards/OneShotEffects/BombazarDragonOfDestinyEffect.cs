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

        public override void Apply(Duel duel)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            duel.Destroy(duel.CreaturePermanents.Where(p => p.Id != Source && duel.GetPower(p) == 6000).ToList());
            // then take an extra turn after this one.
            Turn turn = new Turn { ActivePlayer = Controller, NonActivePlayer = duel.GetOpponent(Controller) };
            duel.ExtraTurns.Enqueue(turn);
            // You lose the game at the end of the extra turn.
            duel.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new AtTheEndOfTurnAbility(turn.Id, new YouLoseTheGameAtTheEndOfTheExtraTurnEffect()), new Once(), Source, Controller));
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

        public override void Apply(Duel duel)
        {
            duel.Lose(duel.GetPlayer(Controller));
        }

        public override OneShotEffect Copy()
        {
            return new YouLoseTheGameAtTheEndOfTheExtraTurnEffect(this);
        }
    }
}
