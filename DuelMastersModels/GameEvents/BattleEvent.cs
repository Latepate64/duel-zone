namespace DuelMastersModels.GameEvents
{
    public class BattleEvent : GameEvent
    {
        public Permanent Creature1 { get; set; }
        public int Creature1Power { get; set; }
        public Permanent Creature2 { get; set; }
        public int Creature2Power { get; set; }

        public BattleEvent(Permanent creature1, int creature1Power, Permanent creature2, int creature2Power)
        {
            Creature1 = creature1;
            Creature1Power = creature1Power;
            Creature2 = creature2;
            Creature2Power = creature2Power;
        }

        public override string ToString(Duel duel)
        {
            return $"{duel.GetOwner(Creature1)}'s {Creature1} ({Creature1Power}) battled {duel.GetOwner(Creature2)}'s {Creature2} ({Creature2Power}).";
        }
    }
}
