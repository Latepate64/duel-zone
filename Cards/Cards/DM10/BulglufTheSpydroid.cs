using Common;

namespace Cards.Cards.DM10
{
    class BulglufTheSpydroid : SilentSkillCreature
    {
        public BulglufTheSpydroid() : base("Bulgluf, the Spydroid", 6, 4000, Subtype.Soltrooper, Civilization.Light)
        {
            AddSilentSkillAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
