using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class StingerHornTheDelver : Engine.Creature
    {
        public StingerHornTheDelver() : base("Stinger Horn, the Delver", 4, 3000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(1000));
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Water));
        }
    }
}
