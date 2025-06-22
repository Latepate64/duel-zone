using ContinuousEffects;

namespace Cards.DM01
{
    sealed class EmeraldGrass : Engine.Creature
    {
        public EmeraldGrass() : base("Emerald Grass", 2, 3000, Interfaces.Race.StarlightTree, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
