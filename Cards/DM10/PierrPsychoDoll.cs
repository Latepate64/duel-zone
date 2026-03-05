using ContinuousEffects;

namespace Cards.DM10
{
    sealed class PierrPsychoDoll : Creature
    {
        public PierrPsychoDoll() : base("Pierr, Psycho Doll", 2, 1000, Interfaces.Race.DeathPuppet, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
