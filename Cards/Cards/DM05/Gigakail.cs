using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class Gigakail : Creature
    {
        public Gigakail() : base("Gigakail", 5, 4000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new CivilizationSlayerEffect(Engine.Civilization.Nature, Engine.Civilization.Light));
        }
    }
}
