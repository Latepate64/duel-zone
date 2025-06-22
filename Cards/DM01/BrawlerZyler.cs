using ContinuousEffects;

namespace Cards.DM01
{
    sealed class BrawlerZyler : Engine.Creature
    {
        public BrawlerZyler() : base("Brawler Zyler", 2, 1000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
