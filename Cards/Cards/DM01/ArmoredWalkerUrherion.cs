using Common;

namespace Cards.Cards.DM01
{
    class ArmoredWalkerUrherion : Creature
    {
        public ArmoredWalkerUrherion() : base("Armored Walker Urherion", 4, 3000, Subtype.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(Subtype.Human, 2000));
        }
    }
}
