namespace Cards.Cards.DM11
{
    class BeratchaTheHiddenGlutton : Creature
    {
        public BeratchaTheHiddenGlutton() : base("Beratcha, the Hidden Glutton", 5, 3000, Engine.Subtype.PandorasBox, Engine.Civilization.Darkness)
        {
            AddSlayerAbility();
        }
    }
}
