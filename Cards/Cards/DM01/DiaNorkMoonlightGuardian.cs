using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class DiaNorkMoonlightGuardian : Creature
    {
        public DiaNorkMoonlightGuardian() : base("Dia Nork, Moonlight Guardian", 4, 5000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility(), new CannotAttackPlayersAbility());
        }
    }
}
