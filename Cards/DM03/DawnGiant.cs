using ContinuousEffects;

namespace Cards.DM03
{
    class DawnGiant : Engine.Creature
    {
        public DawnGiant() : base("Dawn Giant", 7, 11000, Interfaces.Race.Giant, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
