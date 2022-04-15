using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM07
{
    class RodiGaleNightGuardian : Creature
    {
        public RodiGaleNightGuardian() : base("Rodi Gale, Night Guardian", 4, 3500, Engine.Subtype.Guardian, Civilization.Light)
        {
            AddStaticAbilities(new StealthEffect(Civilization.Darkness));
        }
    }
}
