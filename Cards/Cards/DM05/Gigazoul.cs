using Common;

namespace Cards.Cards.DM05
{
    class Gigazoul : Creature
    {
        public Gigazoul() : base("Gigazoul", 3, 3000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.WhileYourOpponentHasNoShieldsThisCreatureCannotAttackAbility());
        }
    }
}
