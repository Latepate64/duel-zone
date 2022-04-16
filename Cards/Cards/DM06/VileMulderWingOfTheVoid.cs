using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class VileMulderWingOfTheVoid : Creature
    {
        public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4, 7000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddDoubleBreakerAbility();
            AddTriggeredAbility(new TriggeredAbilities.WhenThisCreatureBattlesAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
