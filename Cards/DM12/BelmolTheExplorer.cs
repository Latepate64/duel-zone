using ContinuousEffects;

namespace Cards.DM12
{
    class BelmolTheExplorer : Engine.Creature
    {
        public BelmolTheExplorer() : base("Belmol, the Explorer", 2, 3500, Interfaces.Race.Gladiator, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
