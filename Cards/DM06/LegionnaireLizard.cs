using Engine.Abilities;

namespace Cards.DM06
{
    sealed class LegionnaireLizard : Creature
    {
        public LegionnaireLizard() : base("Legionnaire Lizard", 6, 4000, Interfaces.Race.DuneGecko, Interfaces.Civilization.Fire)
        {
            AddAbilities(new TapAbility(new OneShotEffects.OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect()));
        }
    }
}
