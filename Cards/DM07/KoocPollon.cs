using ContinuousEffects;

namespace Cards.DM07
{
    sealed class KoocPollon : Creature
    {
        public KoocPollon() : base("Kooc Pollon", 2, 1000, Interfaces.Race.FireBird, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
        }
    }
}
