using Common;

namespace Cards.Cards.DM07
{
    class RodiGaleNightGuardian : Creature
    {
        public RodiGaleNightGuardian() : base("Rodi Gale, Night Guardian", 4, 3500, Subtype.Guardian, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.StealthAbility(Civilization.Darkness));
        }
    }
}
