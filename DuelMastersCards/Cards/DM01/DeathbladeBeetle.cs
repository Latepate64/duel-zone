using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    public class DeathbladeBeetle : Creature
    {
        public DeathbladeBeetle() : base("Deathblade Beetle", 5, Civilization.Nature, 3000, Subtype.GiantInsect)
        {
            Abilities.Add(new PowerAttackerAbility(4000));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
