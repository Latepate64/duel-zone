using ContinuousEffects;

namespace Cards.DM07
{
    class GezaryUndercoverDoll : Engine.Creature
    {
        public GezaryUndercoverDoll() : base("Gezary, Undercover Doll", 3, 2000, Engine.Race.DeathPuppet, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Nature));
        }
    }
}
