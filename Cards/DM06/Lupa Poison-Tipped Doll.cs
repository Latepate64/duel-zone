using Abilities;

namespace Cards.DM06
{
    sealed class LupaPoisonTippedDoll : Creature
    {
        public LupaPoisonTippedDoll() : base("Lupa, Poison-Tipped Doll", 2, 1000, Interfaces.Race.DeathPuppet, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new TapAbility(new OneShotEffects.OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect()));
        }
    }
}
