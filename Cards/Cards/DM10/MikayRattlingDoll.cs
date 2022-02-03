using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    public class MikayRattlingDoll : Creature
    {
        public MikayRattlingDoll() : base("Mikay, Rattling Doll", 2, Common.Civilization.Darkness, 2000, Common.Subtype.DeathPuppet)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
