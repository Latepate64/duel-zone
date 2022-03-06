using Common;

namespace Cards.Cards.DM11
{
    class BeratchaTheHiddenGlutton : Creature
    {
        public BeratchaTheHiddenGlutton() : base("Beratcha, the Hidden Glutton", 5, 3000, Subtype.PandorasBox, Civilization.Darkness)
        {
            Abilities.Add(new StaticAbilities.SlayerAbility());
        }
    }
}
