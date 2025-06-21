using ContinuousEffects;

namespace Cards.DM06
{
    class ArcBineTheAstounding : EvolutionCreature
    {
        public ArcBineTheAstounding() : base("Arc Bine, the Astounding", 5, 5000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Interfaces.Civilization.Light, new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
        }
    }
}
