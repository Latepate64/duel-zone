using Common;

namespace Cards.Cards.DM10
{
    class PierrPsychoDoll : Creature
    {
        public PierrPsychoDoll() : base("Pierr, Psycho Doll", 2, 1000, Engine.Subtype.DeathPuppet, Civilization.Darkness)
        {
            AddBlockerAbility();
            AddStaticAbilities(new ContinuousEffects.ThisCreatureBlocksIfAble());
            AddThisCreatureCannotAttackAbility();
            AddSlayerAbility();
        }
    }
}
