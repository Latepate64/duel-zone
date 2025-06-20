using ContinuousEffects;

namespace Cards.Cards.DM12
{
    class PeppiPepper : Engine.Creature
    {
        public PeppiPepper() : base("Peppi Pepper", 3, 2000, Engine.Race.FireBird, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
