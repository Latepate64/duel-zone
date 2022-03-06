using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    class Zepimeteus : Creature
    {
        public Zepimeteus() : base("Zepimeteus", 1, 2000, Common.Subtype.SeaHacker, Common.Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
