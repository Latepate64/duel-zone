namespace Cards.Cards.DM03
{
    class WailingShadowBelbetphlo : Creature
    {
        public WailingShadowBelbetphlo() : base("Wailing Shadow Belbetphlo", 3, 1000, Engine.Subtype.Ghost, Engine.Civilization.Darkness)
        {
            AddSlayerAbility();
        }
    }
}
