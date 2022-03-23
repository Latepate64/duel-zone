using Common;

namespace Cards.Cards.DM05
{
    class VashunaSwordDancer : Creature
    {
        public VashunaSwordDancer() : base("Vashuna, Sword Dancer", 5, 7000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.WhileYourOpponentHasNoShieldsThisCreatureCannotAttackAbility(), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
