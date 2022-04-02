using Common;

namespace Cards.Cards.DM12
{
    class BelmolTheExplorer : Creature
    {
        public BelmolTheExplorer() : base("Belmol, the Explorer", 2, 3500, Subtype.Gladiator, Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new ContinuousEffects.ThisCreatureBlocksIfAble());
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
