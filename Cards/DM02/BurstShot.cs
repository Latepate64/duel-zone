using OneShotEffects;

namespace Cards.DM02
{
    class BurstShot : Engine.Spell
    {
        public BurstShot() : base("Burst Shot", 6, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DestroyMaxPowerAreaOfEffect(2000));
        }
    }
}
