using ContinuousEffects;

namespace Cards.DM07
{
    class KoocPollon : Engine.Creature
    {
        public KoocPollon() : base("Kooc Pollon", 2, 1000, Interfaces.Race.FireBird, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
        }
    }
}
