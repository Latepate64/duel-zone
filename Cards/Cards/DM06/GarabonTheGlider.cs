using Common;

namespace Cards.Cards.DM06
{
    class GarabonTheGlider : Creature
    {
        public GarabonTheGlider() : base("Garabon, the Glider", 2, 1000, Engine.Subtype.SnowFaerie, Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
