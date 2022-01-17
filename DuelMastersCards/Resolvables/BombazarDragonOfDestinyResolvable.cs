using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.Durations;
using DuelMastersModels.GameEvents;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class BombazarDragonOfDestinyResolvable : Resolvable
    {
        public BombazarDragonOfDestinyResolvable() : base() { }

        public BombazarDragonOfDestinyResolvable(BombazarDragonOfDestinyResolvable ability) : base(ability)
        {
        }

        public override void Resolve(Duel duel)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            duel.Destroy(duel.CreaturePermanents.Where(p => p.Id != Source && duel.GetPower(p) == 6000).ToList());
            // then take an extra turn after this one.
            Turn turn = new Turn { ActivePlayer = Controller, NonActivePlayer = duel.GetOpponent(Controller) };
            duel.ExtraTurns.Enqueue(turn);
            // You lose the game at the end of the extra turn.
            duel.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(new AtTheEndOfTurnAbility(turn.Id, new YouLoseTheGameAtTheEndOfTheExtraTurnResolvable()), new Once(), Source, Controller));
        }

        public override Resolvable Copy()
        {
            return new BombazarDragonOfDestinyResolvable(this);
        }
    }

    public class YouLoseTheGameAtTheEndOfTheExtraTurnResolvable : Resolvable
    {
        public YouLoseTheGameAtTheEndOfTheExtraTurnResolvable() : base()
        {
        }

        public YouLoseTheGameAtTheEndOfTheExtraTurnResolvable(YouLoseTheGameAtTheEndOfTheExtraTurnResolvable ability) : base(ability)
        {
        }

        public override void Resolve(Duel duel)
        {
            duel.Lose(duel.GetPlayer(Controller));
        }

        public override Resolvable Copy()
        {
            return new YouLoseTheGameAtTheEndOfTheExtraTurnResolvable(this);
        }
    }
}
