using Common;

namespace Cards.Cards.DM10
{
    class ChargeWhipper : SilentSkillCreature
    {
        public ChargeWhipper() : base("Charge Whipper", 3, 2000, Engine.Subtype.CyberVirus, Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.EmeralEffect());
        }
    }
}
