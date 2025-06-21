using ContinuousEffects;

namespace Cards.DM01
{
    class Stonesaur : Engine.Creature
    {
        public Stonesaur() : base("Stonesaur", 5, 4000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
