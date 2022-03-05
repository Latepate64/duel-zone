using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM05
{
    class BolgashDragon : Creature
    {
        public BolgashDragon() : base("Bolgash Dragon", 8, Civilization.Fire, 4000, Subtype.ArmoredDragon)
        {
            Abilities.Add(new PowerAttackerAbility(8000));
            Abilities.Add(new TripleBreakerAbility());
        }
    }
}
