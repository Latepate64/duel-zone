namespace Cards.Cards.DM02
{
    class CavalryGeneralCuratops : Creature
    {
        public CavalryGeneralCuratops() : base("Cavalry General Curatops", 3, Common.Civilization.Fire, 2000, Common.Subtype.Dragonoid)
        {
            Abilities.Add(new StaticAbilities.CanAttackUntappedCreaturesAbility());
        }
    }
}
