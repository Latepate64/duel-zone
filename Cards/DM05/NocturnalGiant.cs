using ContinuousEffects;

namespace Cards.DM05
{
    sealed class NocturnalGiant : Engine.Creature
    {
        public NocturnalGiant() : base("Nocturnal Giant", 7, 7000, Interfaces.Race.Giant, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddStaticAbilities(new PowerAttackerEffect(7000));
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }
}
