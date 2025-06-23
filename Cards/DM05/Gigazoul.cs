using ContinuousEffects;

namespace Cards.DM05
{
    sealed class Gigazoul : Creature
    {
        public Gigazoul() : base("Gigazoul", 3, 3000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect());
        }
    }
}
