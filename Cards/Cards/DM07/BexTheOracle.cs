using Common;

namespace Cards.Cards.DM07
{
    class BexTheOracle : Creature
    {
        public BexTheOracle() : base("Bex, the Oracle", 3, 2500, Subtype.LightBringer, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.WhileYouHaveNoShieldsAbility(new StaticAbilities.BlockerAbility()));
        }
    }
}
