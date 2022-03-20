using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class ArmoredWalkerUrherion : Creature
    {
        public ArmoredWalkerUrherion() : base("Armored Walker Urherion", 4, 3000, Subtype.Armorloid, Civilization.Fire)
        {
            AddAbilities(new WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksAbility(Subtype.Human, 2000));
        }
    }
}
