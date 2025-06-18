namespace Engine.GameEvents
{
    public class BattleEvent(Creature attackingCreature, Creature defendingCreature) : GameEvent
    {
        public Creature AttackingCreature { get; } = attackingCreature;
        public Creature DefendingCreature { get; } = defendingCreature;
        public Creature[] Winners { get; private set; } = [];

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

            void Outcome(Creature winner, Creature loser)
            {
                Winners = [winner];
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

        private static void CheckLoseInBattle(Creature target, Creature against, IGame game)
        {
            if (!game.ContinuousEffects.DoesCreatureGetDestroyedInBattle(against, target))
            {
                target.SetLostInBattle();
            }
        }
    }
}
