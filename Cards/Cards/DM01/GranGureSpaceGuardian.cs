using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class GranGureSpaceGuardian : Creature
    {
        public GranGureSpaceGuardian() : base("Gran Gure, Space Guardian", 6, 9000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new CannotAttackPlayersAbility());
        }
    }
}
