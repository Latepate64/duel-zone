namespace Cards.Cards.DM10
{
    class PierrPsychoDoll : Creature
    {
        public PierrPsychoDoll() : base("Pierr, Psycho Doll", 2, 1000, Engine.Race.DeathPuppet, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureBlocksIfAble();
            AddThisCreatureCannotAttackAbility();
            AddSlayerAbility();
        }
    }
}
