using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class GarabonTheGlider : Engine.Creature
    {
        public GarabonTheGlider() : base("Garabon, the Glider", 2, 1000, Engine.Race.SnowFaerie, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
