using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    class VileMulderWingOfTheVoid : Engine.Creature
    {
        public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4, 7000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
