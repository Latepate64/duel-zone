using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class DiaNorkMoonlightGuardian : Creature
    {
        public DiaNorkMoonlightGuardian() : base("Dia Nork, Moonlight Guardian", 4, Civilization.Light, 5000, Subtype.Guardian)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
