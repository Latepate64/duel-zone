using OneShotEffects;

namespace Cards.DM02
{
    sealed class BurstShot : Spell
    {
        public BurstShot() : base("Burst Shot", 6, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DestroyMaxPowerAreaOfEffect(2000));
        }
    }
}
