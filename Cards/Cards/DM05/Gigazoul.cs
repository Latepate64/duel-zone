using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class Gigazoul : Creature
    {
        public Gigazoul() : base("Gigazoul", 3, 3000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new WhileYourOpponentHasNoShieldsThisCreatureCannotAttackEffect());
        }
    }
}
