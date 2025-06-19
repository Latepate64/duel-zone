using Cards.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class AdventureBoar : Engine.Creature
    {
        public AdventureBoar() : base("Adventure Boar", 2, 1000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
