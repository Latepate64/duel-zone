using Common;

namespace Cards.Cards.DM06
{
    class GarabonTheGlider : Creature
    {
        public GarabonTheGlider() : base("Garabon, the Glider", 2, 1000, Subtype.SnowFaerie, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(2000));
        }
    }
}
