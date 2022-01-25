using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    class BrawlerZyler : Creature
    {
        public BrawlerZyler() : base("Brawler Zyler", 2, Civilization.Fire, 1000, Subtype.Human)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
