using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class GranGureSpaceGuardian : Creature
    {
        public GranGureSpaceGuardian() : base("Gran Gure, Space Guardian", 6, Common.Civilization.Light, 9000, Common.Subtype.Guardian)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
