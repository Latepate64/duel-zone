using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    public class SzubsKinTwilightGuardian : Creature
    {
        public SzubsKinTwilightGuardian() : base("Szubs Kin, Twilight Guardian", 5, Civilization.Light, 6000, Subtype.Guardian)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
