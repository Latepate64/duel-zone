using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class NocturnalGiant : Creature
    {
        public NocturnalGiant() : base("Nocturnal Giant", 7, 7000, Subtype.Giant, Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddPowerAttackerAbility(7000);
            AddTripleBreakerAbility();
        }
    }
}
