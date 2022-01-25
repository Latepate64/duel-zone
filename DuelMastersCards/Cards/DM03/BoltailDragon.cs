using DuelMastersModels;

namespace DuelMastersCards.Cards.DM03
{
    class BoltailDragon : Creature
    {
        public BoltailDragon() : base("Boltail Dragon", 7, Civilization.Fire, 9000, Subtype.ArmoredDragon)
        {
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
