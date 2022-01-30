using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    class BrawlerZyler : Creature
    {
        public BrawlerZyler() : base("Brawler Zyler", 2, Civilization.Fire, 1000, Subtype.Human)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
