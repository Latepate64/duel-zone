using ContinuousEffects;

namespace Cards.DM05
{
    sealed class VashunaSwordDancer : Engine.Creature
    {
        public VashunaSwordDancer() : base("Vashuna, Sword Dancer", 5, 7000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
