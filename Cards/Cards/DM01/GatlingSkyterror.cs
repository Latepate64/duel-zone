namespace Cards.Cards.DM01
{
    class GatlingSkyterror : Creature
    {
        public GatlingSkyterror() : base("Gatling Skyterror", 7, 7000, Engine.Subtype.ArmoredWyvern, Common.Civilization.Fire)
        {
            AddThisCreatureCanAttackUntappedCreaturesAbility();
            AddDoubleBreakerAbility();
        }
    }
}
