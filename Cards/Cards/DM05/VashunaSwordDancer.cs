using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM05
{
    class VashunaSwordDancer : Engine.Creature
    {
        public VashunaSwordDancer() : base("Vashuna, Sword Dancer", 5, 7000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
