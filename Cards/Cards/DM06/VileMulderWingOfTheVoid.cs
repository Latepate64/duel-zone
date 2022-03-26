using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class VileMulderWingOfTheVoid : Creature
    {
        public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4, 7000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new ThisCreatureCannotAttackCreaturesAbility(), new DoubleBreakerAbility(), new TriggeredAbilities.WhenThisCreatureBattlesAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
