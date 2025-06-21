using ContinuousEffects;

namespace Cards.DM01
{
    class EmeraldGrass : Engine.Creature
    {
        public EmeraldGrass() : base("Emerald Grass", 2, 3000, Engine.Race.StarlightTree, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
