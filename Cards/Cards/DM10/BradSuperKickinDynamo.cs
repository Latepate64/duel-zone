using Common;

namespace Cards.Cards.DM10
{
    class BradSuperKickinDynamo : SilentSkillCreature
    {
        public BradSuperKickinDynamo() : base("Brad, Super Kickin' Dynamo", 3, 2000, Engine.Subtype.Human, Civilization.Fire)
        {
            AddSilentSkillAbility(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect());
        }
    }
}
