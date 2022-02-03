using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class BrawlerZyler : Creature
    {
        public BrawlerZyler() : base("Brawler Zyler", 2, Common.Civilization.Fire, 1000, Common.Subtype.Human)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
