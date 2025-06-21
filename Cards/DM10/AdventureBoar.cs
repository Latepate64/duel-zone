using ContinuousEffects;

namespace Cards.DM10
{
    class AdventureBoar : Engine.Creature
    {
        public AdventureBoar() : base("Adventure Boar", 2, 1000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
