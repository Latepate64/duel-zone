using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class BexTheOracle : Creature
    {
        public BexTheOracle() : base("Bex, the Oracle", 3, 2500, Engine.Subtype.LightBringer, Engine.Civilization.Light)
        {
            AddStaticAbilities(new WhileYouHaveNoShieldsEffect(new StaticAbilities.BlockerAbility()));
        }
    }
}
