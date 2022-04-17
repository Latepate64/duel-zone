using Cards.OneShotEffects;

namespace Cards.Cards.DM02
{
    class BurstShot : Spell
    {
        public BurstShot() : base("Burst Shot", 6, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DestroyMaxPowerAreaOfEffect(2000));
        }
    }
}
