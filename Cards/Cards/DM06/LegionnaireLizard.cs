using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class LegionnaireLizard : Creature
    {
        public LegionnaireLizard() : base("Legionnaire Lizard", 6, 4000, Engine.Race.DuneGecko, Engine.Civilization.Fire)
        {
            AddAbilities(new TapAbility(new OneShotEffects.OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect()));
        }
    }
}
