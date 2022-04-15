namespace Cards.Cards.DM01
{
    class MarineFlower : Creature
    {
        public MarineFlower() : base("Marine Flower", 1, 2000, Engine.Subtype.CyberVirus, Common.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
