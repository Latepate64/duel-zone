using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class NocturnalGiant : Creature
    {
        public NocturnalGiant() : base("Nocturnal Giant", 7, 7000, Engine.Race.Giant, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddStaticAbilities(new PowerAttackerEffect(7000));
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }
}
