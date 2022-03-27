using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class SzubsKinTwilightGuardian : Creature
    {
        public SzubsKinTwilightGuardian() : base("Szubs Kin, Twilight Guardian", 5, 6000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new ThisCreatureCannotAttackPlayersAbility());
        }
    }
}
