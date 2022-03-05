using Common;

namespace Cards.Cards.DM11
{
    class BeratchaTheHiddenGlutton : Creature
    {
        public BeratchaTheHiddenGlutton() : base("Beratcha, the Hidden Glutton", 5, Civilization.Darkness, 3000, Subtype.PandorasBox)
        {
            Abilities.Add(new StaticAbilities.SlayerAbility());
        }
    }
}
