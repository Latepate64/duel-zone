namespace Cards.Cards.DM02
{
    class CavalryGeneralCuratops : Creature
    {
        public CavalryGeneralCuratops() : base("Cavalry General Curatops", 3, 2000, Common.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.CanAttackUntappedCreaturesAbility());
        }
    }
}
