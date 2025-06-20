using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM10
{
    class PierrPsychoDoll : Engine.Creature
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
