using ContinuousEffects;

namespace Cards.DM01
{
    class SenatineJadeTree : Engine.Creature
    {
        public SenatineJadeTree() : base("Senatine Jade Tree", 3, 4000, Engine.Race.StarlightTree, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
