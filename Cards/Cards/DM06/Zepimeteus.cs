using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    class Zepimeteus : Creature
    {
        public Zepimeteus() : base("Zepimeteus", 1, 2000, Common.Subtype.SeaHacker, Common.Civilization.Water)
        {
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackCreaturesAbility(), new CannotAttackPlayersAbility());
        }
    }
}
