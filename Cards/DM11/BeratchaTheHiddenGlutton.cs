using ContinuousEffects;

namespace Cards.DM11
{
    sealed class BeratchaTheHiddenGlutton : Engine.Creature
    {
        public BeratchaTheHiddenGlutton() : base("Beratcha, the Hidden Glutton", 5, 3000, Interfaces.Race.PandorasBox, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
