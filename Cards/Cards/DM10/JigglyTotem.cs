namespace Cards.Cards.DM10
{
    class JigglyTotem : Creature
    {
        public JigglyTotem() : base("Jiggly Totem", 4, 1000, Engine.Race.MysteryTotem, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.JigglyTotemEffect(1000));
        }
    }
}
