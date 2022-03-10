using Common;

namespace Cards.Cards.DM10
{
    class GaulezalDragon : Creature
    {
        public GaulezalDragon() : base("Gaulezal Dragon", 9, 11000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
