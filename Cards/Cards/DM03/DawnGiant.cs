using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class DawnGiant : Engine.Creature
    {
        public DawnGiant() : base("Dawn Giant", 7, 11000, Engine.Race.Giant, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
