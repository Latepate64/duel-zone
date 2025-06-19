using Effects.Continuous;

namespace Cards.Cards.DM11
{
    class BeratchaTheHiddenGlutton : Engine.Creature
    {
        public BeratchaTheHiddenGlutton() : base("Beratcha, the Hidden Glutton", 5, 3000, Engine.Race.PandorasBox, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
