using ContinuousEffects;

namespace Cards.DM07
{
    class RodiGaleNightGuardian : Engine.Creature
    {
        public RodiGaleNightGuardian() : base("Rodi Gale, Night Guardian", 4, 3500, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Darkness));
        }
    }
}
