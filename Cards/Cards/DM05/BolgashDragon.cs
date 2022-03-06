using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM05
{
    class BolgashDragon : Creature
    {
        public BolgashDragon() : base("Bolgash Dragon", 8, 4000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            Abilities.Add(new PowerAttackerAbility(8000));
            Abilities.Add(new TripleBreakerAbility());
        }
    }
}
