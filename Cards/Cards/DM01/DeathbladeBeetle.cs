using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class DeathbladeBeetle : Creature
    {
        public DeathbladeBeetle() : base("Deathblade Beetle", 5, 3000, Common.Subtype.GiantInsect, Common.Civilization.Nature)
        {
            AddAbilities(new PowerAttackerAbility(4000), new DoubleBreakerAbility());
        }
    }
}
