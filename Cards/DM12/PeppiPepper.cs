using ContinuousEffects;

namespace Cards.DM12
{
    class PeppiPepper : Engine.Creature
    {
        public PeppiPepper() : base("Peppi Pepper", 3, 2000, Interfaces.Race.FireBird, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
