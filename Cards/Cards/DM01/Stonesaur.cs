using ContinuousEffects;

namespace Cards.Cards.DM01
{
    class Stonesaur : Engine.Creature
    {
        public Stonesaur() : base("Stonesaur", 5, 4000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
