using Engine.Abilities;

namespace Cards.DM06
{
    class LupaPoisonTippedDoll : Engine.Creature
    {
        public LupaPoisonTippedDoll() : base("Lupa, Poison-Tipped Doll", 2, 1000, Interfaces.Race.DeathPuppet, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new TapAbility(new OneShotEffects.OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect()));
        }
    }
}
