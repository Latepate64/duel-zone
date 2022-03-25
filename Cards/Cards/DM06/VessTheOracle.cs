using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    class VessTheOracle : Creature
    {
        public VessTheOracle() : base("Vess, the Oracle", 1, 2000, Common.Subtype.LightBringer, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new ThisCreatureCannotAttackPlayersAbility());
        }
    }
}
