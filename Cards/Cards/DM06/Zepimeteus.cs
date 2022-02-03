using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    public class Zepimeteus : Creature
    {
        public Zepimeteus() : base("Zepimeteus", 1, Common.Civilization.Water, 2000, Common.Subtype.SeaHacker)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
