using ContinuousEffects;

namespace Cards.DM06
{
    sealed class GarabonTheGlider : Engine.Creature
    {
        public GarabonTheGlider() : base("Garabon, the Glider", 2, 1000, Interfaces.Race.SnowFaerie, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
