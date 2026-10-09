using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM06
{
    sealed class CursedPincher : Creature
    {
        public CursedPincher() : base("Cursed Pincher", 4, 2000, Interfaces.Race.BrainJacker, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new SlayerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
