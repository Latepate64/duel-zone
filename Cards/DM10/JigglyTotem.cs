namespace Cards.DM10
{
    sealed class JigglyTotem : Creature
    {
        public JigglyTotem() : base("Jiggly Totem", 4, 1000, Interfaces.Race.MysteryTotem, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.JigglyTotemEffect(1000));
        }
    }
}
