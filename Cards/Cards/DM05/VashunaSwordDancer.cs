using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class VashunaSwordDancer : Creature
    {
        public VashunaSwordDancer() : base("Vashuna, Sword Dancer", 5, 7000, Engine.Subtype.DemonCommand, Civilization.Darkness)
        {
            AddStaticAbilities(new WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect());
            AddDoubleBreakerAbility();
        }
    }
}
