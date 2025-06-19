using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class BrawlerZyler : Creature
    {
        public BrawlerZyler() : base("Brawler Zyler", 2, 1000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
