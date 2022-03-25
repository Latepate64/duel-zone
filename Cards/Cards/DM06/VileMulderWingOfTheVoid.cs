using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class VileMulderWingOfTheVoid : Creature
    {
        public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4, 7000, Subtype.DemonCommand, Civilization.Darkness)
        {
            // When this creature battles, destroy it after the battle.
            AddAbilities(new ThisCreatureCannotAttackCreaturesAbility(), new DoubleBreakerAbility(), new TriggeredAbilities.BattleAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
