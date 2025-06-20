using Abilities.Triggered;
using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM06
{
    class VileMulderWingOfTheVoid : Engine.Creature
    {
        public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4, 7000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
