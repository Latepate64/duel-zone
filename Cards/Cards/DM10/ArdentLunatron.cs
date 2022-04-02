using Common;

namespace Cards.Cards.DM10
{
    class ArdentLunatron : Creature
    {
        public ArdentLunatron() : base("Ardent Lunatron", 3, 5000, Subtype.CyberMoon, Civilization.Water)
        {
            AddBlockerAbility();
            AddStaticAbilities(new ContinuousEffects.ThisCreatureBlocksIfAble());
            AddThisCreatureCannotAttackAbility();
        }
    }
}
