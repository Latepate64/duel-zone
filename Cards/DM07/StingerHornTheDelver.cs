using ContinuousEffects;

namespace Cards.DM07
{
    sealed class StingerHornTheDelver : Engine.Creature
    {
        public StingerHornTheDelver() : base("Stinger Horn, the Delver", 4, 3000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(1000));
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Water));
        }
    }
}
