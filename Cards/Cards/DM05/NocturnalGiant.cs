using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class NocturnalGiant : Creature
    {
        public NocturnalGiant() : base("Nocturnal Giant", 7, 7000, Engine.Subtype.Giant, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddPowerAttackerAbility(7000);
            AddTripleBreakerAbility();
        }
    }
}
