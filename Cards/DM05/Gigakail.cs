using ContinuousEffects;

namespace Cards.DM05
{
    class Gigakail : Engine.Creature
    {
        public Gigakail() : base("Gigakail", 5, 4000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new CivilizationSlayerEffect(Interfaces.Civilization.Nature, Interfaces.Civilization.Light));
        }
    }
}
