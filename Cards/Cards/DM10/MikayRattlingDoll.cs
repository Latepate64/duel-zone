using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    class MikayRattlingDoll : Creature
    {
        public MikayRattlingDoll() : base("Mikay, Rattling Doll", 2, 2000, Common.Subtype.DeathPuppet, Common.Civilization.Darkness)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
