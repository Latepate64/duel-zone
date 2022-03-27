using Common;

namespace Cards.Cards.DM05
{
    class NocturnalGiant : Creature
    {
        public NocturnalGiant() : base("Nocturnal Giant", 7, 7000, Subtype.Giant, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.CannotAttackCreaturesAbility(), new StaticAbilities.PowerAttackerAbility(7000), new StaticAbilities.TripleBreakerAbility());
        }
    }
}
