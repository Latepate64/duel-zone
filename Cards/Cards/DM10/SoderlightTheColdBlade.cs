using Common;

namespace Cards.Cards.DM10
{
    class SoderlightTheColdBlade : SilentSkillCreature
    {
        public SoderlightTheColdBlade() : base("Soderlight, the Cold Blade", 4, 4000, Engine.Subtype.SpiritQuartz, Civilization.Water, Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.OpponentSacrificeEffect());
        }
    }
}
