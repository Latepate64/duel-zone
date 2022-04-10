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

        public override void Happen(IGame game)
        {
            // Battle event must be processed relative to both creatures.
            //Process(new BattleEvent { Card = attackingCreature.Convert(), OtherCard = defendingCreature.Convert() });
            //Process(new BattleEvent { Card = defendingCreature.Convert(), OtherCard = attackingCreature.Convert() });

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

            //Process(new AfterBattleEvent());

            void Outcome(ICard winner, ICard loser)
            {
                //Process(new WinBattleEvent { Card = winner.Convert() });
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

        private void CheckLoseInBattle(ICard target, ICard against, IGame game)
        {
            if (!game.GetContinuousEffects<INotDestroyedInBattleEffect>().Any(x => x.Applies(against, target, game)))
            {
                target.LostInBattle = true;
            }
        }
    }
}
