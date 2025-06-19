using Cards.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class PierrPsychoDoll : Creature
    {
        public PierrPsychoDoll() : base("Pierr, Psycho Doll", 2, 1000, Engine.Race.DeathPuppet, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
