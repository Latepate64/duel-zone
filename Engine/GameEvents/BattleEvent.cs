using Interfaces;

namespace Engine.GameEvents
{
    public class BattleEvent(ICreature attackingCreature, ICreature defendingCreature) : GameEvent
    {
        public ICreature AttackingCreature { get; } = attackingCreature;
        public ICreature DefendingCreature { get; } = defendingCreature;
        public ICreature[] Winners { get; private set; } = [];

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

            void Outcome(ICreature winner, ICreature loser)
            {
                Winners = [winner];
                CheckLoseInBattle(loser, winner, game);
                if (game.ContinuousEffects.DoesAnySlayerEffectApply(loser, winner))
                {
                    // winner.SetLostInBattle(); // TODO: Not sure if proper way to do
                }
            }
        }

        public override string ToString()
        {
            return $"{AttackingCreature} battled {DefendingCreature}.";
        }

        private static void CheckLoseInBattle(ICreature target, ICreature against, IGame game)
        {
            if (!game.ContinuousEffects.DoesCreatureGetDestroyedInBattle(against, target))
            {
                // target.SetLostInBattle();
            }
        }
    }
}
