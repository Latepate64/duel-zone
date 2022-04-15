namespace Cards.Cards.DM01
{
    class FaerieChild : Creature
    {
        public FaerieChild() : base("Faerie Child", 4, 2000, Engine.Subtype.CyberVirus, Common.Civilization.Water)
        {
            AddThisCreatureCannotBeBlockedAbility();
        }
    }
}
