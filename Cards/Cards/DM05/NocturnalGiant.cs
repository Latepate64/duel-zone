using ContinuousEffects;

namespace Cards.Cards.DM05
{
    class NocturnalGiant : Engine.Creature
    {
        public NocturnalGiant() : base("Nocturnal Giant", 7, 7000, Engine.Race.Giant, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddStaticAbilities(new PowerAttackerEffect(7000));
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }
}
