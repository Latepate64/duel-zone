using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM06
{
    class ArcBineTheAstounding : EvolutionCreature
    {
        public ArcBineTheAstounding() : base("Arc Bine, the Astounding", 5, 5000, Engine.Subtype.Guardian, Civilization.Light)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Civilization.Light, new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
        }
    }
}
