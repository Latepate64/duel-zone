using Cards.ContinuousEffects;

namespace Cards.Cards.DM12
{
    class BelmolTheExplorer : Creature
    {
        public BelmolTheExplorer() : base("Belmol, the Explorer", 2, 3500, Engine.Race.Gladiator, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
