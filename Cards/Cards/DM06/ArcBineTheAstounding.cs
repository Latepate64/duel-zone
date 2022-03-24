using Common;

namespace Cards.Cards.DM06
{
    class ArcBineTheAstounding : EvolutionCreature
    {
        public ArcBineTheAstounding() : base("Arc Bine, the Astounding", 5, 5000, Subtype.Guardian, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.TapAbilityAddingAbility(Civilization.Light, new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
        }
    }
}
