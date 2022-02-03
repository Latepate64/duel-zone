using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class DiaNorkMoonlightGuardian : Creature
    {
        public DiaNorkMoonlightGuardian() : base("Dia Nork, Moonlight Guardian", 4, Common.Civilization.Light, 5000, Common.Subtype.Guardian)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
