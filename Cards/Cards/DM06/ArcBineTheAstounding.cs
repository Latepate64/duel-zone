using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class ArcBineTheAstounding : EvolutionCreature
    {
        public ArcBineTheAstounding() : base("Arc Bine, the Astounding", 5, 5000, Engine.Subtype.Guardian, Engine.Civilization.Light)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Engine.Civilization.Light, new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
        }
    }
}
