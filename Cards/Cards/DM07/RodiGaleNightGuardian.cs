using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class RodiGaleNightGuardian : Creature
    {
        public RodiGaleNightGuardian() : base("Rodi Gale, Night Guardian", 4, 3500, Engine.Subtype.Guardian, Engine.Civilization.Light)
        {
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Darkness));
        }
    }
}
