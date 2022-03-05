using Common;

namespace Cards.Cards.DM06
{
    public class VileMulderWingOfTheVoid : Creature
    {
        public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4, Civilization.Darkness, 7000, Subtype.DemonCommand)
        {
            Abilities.Add(new StaticAbilities.CannotAttackCreaturesAbility());
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());

            // When this creature battles, destroy it after the battle.
            Abilities.Add(new TriggeredAbilities.BattleAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
