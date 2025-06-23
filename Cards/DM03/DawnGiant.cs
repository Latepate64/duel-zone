using ContinuousEffects;

namespace Cards.DM03
{
    sealed class DawnGiant : Creature
    {
        public DawnGiant() : base("Dawn Giant", 7, 11000, Interfaces.Race.Giant, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
