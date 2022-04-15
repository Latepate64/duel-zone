using Common;

namespace Cards.Cards.DM06
{
    class LupaPoisonTippedDoll : Creature
    {
        public LupaPoisonTippedDoll() : base("Lupa, Poison-Tipped Doll", 2, 1000, Engine.Subtype.DeathPuppet, Civilization.Darkness)
        {
            AddTapAbility(new OneShotEffects.OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(new StaticAbilities.SlayerAbility()));
        }
    }
}
