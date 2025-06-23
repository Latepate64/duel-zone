using ContinuousEffects;

namespace Cards.DM07
{
    sealed class GezaryUndercoverDoll : Creature
    {
        public GezaryUndercoverDoll() : base("Gezary, Undercover Doll", 3, 2000, Interfaces.Race.DeathPuppet, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Nature));
        }
    }
}
