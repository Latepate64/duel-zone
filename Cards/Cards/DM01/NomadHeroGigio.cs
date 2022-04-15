namespace Cards.Cards.DM01
{
    class NomadHeroGigio : Creature
    {
        public NomadHeroGigio() : base("Nomad Hero Gigio", 5, 3000, Engine.Subtype.MachineEater, Engine.Civilization.Fire)
        {
            AddThisCreatureCanAttackUntappedCreaturesAbility();
        }
    }
}
