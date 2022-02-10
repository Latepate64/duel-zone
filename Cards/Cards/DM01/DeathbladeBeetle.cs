using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class DeathbladeBeetle : Creature
    {
        public DeathbladeBeetle() : base("Deathblade Beetle", 5, Common.Civilization.Nature, 3000, Common.Subtype.GiantInsect)
        {
            Abilities.Add(new PowerAttackerAbility(4000));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
