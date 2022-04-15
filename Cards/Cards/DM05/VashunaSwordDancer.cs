using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class VashunaSwordDancer : Creature
    {
        public VashunaSwordDancer() : base("Vashuna, Sword Dancer", 5, 7000, Engine.Subtype.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect());
            AddDoubleBreakerAbility();
        }
    }
}
