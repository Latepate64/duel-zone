namespace Cards.Cards.DM06
{
    class GarabonTheGlider : Creature
    {
        public GarabonTheGlider() : base("Garabon, the Glider", 2, 1000, Engine.Subtype.SnowFaerie, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
