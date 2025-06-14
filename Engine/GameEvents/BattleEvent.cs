using Engine.ContinuousEffects;
using System.Linq;

namespace Engine.GameEvents
{
    public class BattleEvent(Card attackingCreature, Card defendingCreature) : GameEvent
    {
        public Card AttackingCreature { get; } = attackingCreature;
        public Card DefendingCreature { get; } = defendingCreature;
        public Card[] Winners { get; private set; } = System.Array.Empty<Card>();

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

            void Outcome(Card winner, Card loser)
            {
                Winners = new Card[] { winner };
                CheckLoseInBattle(loser, winner, game);
                if (game.ContinuousEffects.DoesAnySlayerEffectApply(loser, winner))
                {
                    winner.SetLostInBattle(); // TODO: Not sure if proper way to do
                }
            }
        }

        public override string ToString()
        {
            return $"{AttackingCreature} battled {DefendingCreature}.";
        }

        private static void CheckLoseInBattle(Card target, Card against, IGame game)
        {
            if (!game.ContinuousEffects.DoesCreatureGetDestroyedInBattle(against, target))
            {
                target.SetLostInBattle();
            }
        }
    }
}
