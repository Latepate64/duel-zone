using Engine.ContinuousEffects;
using System.Linq;

namespace Engine.GameEvents
{
    public class BattleEvent : GameEvent
    {
        public BattleEvent(ICard attackingCreature, ICard defendingCreature)
        {
            AttackingCreature = attackingCreature;
            DefendingCreature = defendingCreature;
        }

        public ICard AttackingCreature { get; }
        public ICard DefendingCreature { get; }
        public ICard[] Winners { get; private set; }

        public override void Happen(IGame game)
        {
            if (AttackingCreature.Power.Value > DefendingCreature.Power.Value)
            {
                Outcome(AttackingCreature, DefendingCreature);
            }
            else if (AttackingCreature.Power.Value < DefendingCreature.Power.Value)
            {
                Outcome(DefendingCreature, AttackingCreature);
            }
            else
            {
                CheckLoseInBattle(AttackingCreature, DefendingCreature, game);
                CheckLoseInBattle(DefendingCreature, AttackingCreature, game);
            }

            void Outcome(ICard winner, ICard loser)
            {
                Winners = new ICard[] { winner };
                CheckLoseInBattle(loser, winner, game);
                if (game.GetContinuousEffects<ISlayerEffect>().Any(x => x.Applies(loser, winner, game)))
                {
                    winner.LostInBattle = true; // TODO: Not sure if proper way to do
                }
            }
        }

        public override string ToString()
        {
            return $"{AttackingCreature} battled {DefendingCreature}.";
        }

        private static void CheckLoseInBattle(ICard target, ICard against, IGame game)
        {
            if (!game.GetContinuousEffects<INotDestroyedInBattleEffect>().Any(x => x.Applies(against, target, game)))
            {
                target.LostInBattle = true;
            }
        }
    }
}
