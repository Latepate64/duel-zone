using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM10
{
    public class MikayRattlingDoll : Creature
    {
        public MikayRattlingDoll() : base("Mikay, Rattling Doll", 2, Civilization.Darkness, 2000, Subtype.DeathPuppet)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
