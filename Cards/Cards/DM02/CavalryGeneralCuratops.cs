namespace Cards.Cards.DM02
{
    class CavalryGeneralCuratops : Creature
    {
        public CavalryGeneralCuratops() : base("Cavalry General Curatops", 3, 2000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddThisCreatureCanAttackUntappedCreaturesAbility();
        }
    }
}
