namespace Cards.Cards.DM12
{
    class HypersprintWariorUzesol : Creature
    {
        public HypersprintWariorUzesol() : base("Hypersprint Warior Uzesol", 4, 1000, Engine.Subtype.Armorloid, Engine.Civilization.Fire)
        {
            AddSpeedAttackerAbility();
            AddPowerAttackerAbility(4000);
        }
    }
}
