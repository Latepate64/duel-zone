using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class StingerHornTheDelver : Creature
    {
        public StingerHornTheDelver() : base("Stinger Horn, the Delver", 4, 3000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(1000);
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Water));
        }
    }
}
