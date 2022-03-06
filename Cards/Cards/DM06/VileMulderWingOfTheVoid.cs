using Common;

namespace Cards.Cards.DM06
{
    class VileMulderWingOfTheVoid : Creature
    {
        public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4, 7000, Subtype.DemonCommand, Civilization.Darkness)
        {
            Abilities.Add(new StaticAbilities.CannotAttackCreaturesAbility());
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());

            // When this creature battles, destroy it after the battle.
            Abilities.Add(new TriggeredAbilities.BattleAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
