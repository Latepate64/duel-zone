using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM05
{
    class BolgashDragon : Creature
    {
        public BolgashDragon() : base("Bolgash Dragon", 8, 4000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new PowerAttackerAbility(8000));
            AddAbilities(new TripleBreakerAbility());
        }
    }
}
