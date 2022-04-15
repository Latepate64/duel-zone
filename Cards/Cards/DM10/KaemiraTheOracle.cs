using Common;

namespace Cards.Cards.DM10
{
    class KaemiraTheOracle : SilentSkillCreature
    {
        public KaemiraTheOracle() : base("Kaemira, the Oracle", 4, 1000, Engine.Subtype.LightBringer, Civilization.Light)
        {
            AddSilentSkillAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
