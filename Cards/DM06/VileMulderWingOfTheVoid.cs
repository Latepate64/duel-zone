using Abilities.Static;
using ContinuousEffects.CannotAttackCreatures;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class VileMulderWingOfTheVoid : Creature
    {
        public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4, 7000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
            AddAbilities(new DoubleBreakerAbility());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
