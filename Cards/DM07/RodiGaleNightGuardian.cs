using ContinuousEffects;

namespace Cards.DM07
{
    class RodiGaleNightGuardian : Engine.Creature
    {
        public RodiGaleNightGuardian() : base("Rodi Gale, Night Guardian", 4, 3500, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Darkness));
        }
    }
}
