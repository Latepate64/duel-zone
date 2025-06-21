using Engine.Abilities;

namespace Cards.DM06
{
    class LegionnaireLizard : Engine.Creature
    {
        public LegionnaireLizard() : base("Legionnaire Lizard", 6, 4000, Interfaces.Race.DuneGecko, Interfaces.Civilization.Fire)
        {
            AddAbilities(new TapAbility(new OneShotEffects.OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect()));
        }
    }
}
