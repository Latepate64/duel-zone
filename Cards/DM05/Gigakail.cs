using ContinuousEffects;

namespace Cards.DM05
{
    class Gigakail : Engine.Creature
    {
        public Gigakail() : base("Gigakail", 5, 4000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new CivilizationSlayerEffect(Engine.Civilization.Nature, Engine.Civilization.Light));
        }
    }
}
