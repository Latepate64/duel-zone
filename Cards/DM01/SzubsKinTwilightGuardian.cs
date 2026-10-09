using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM01
{
    sealed class SzubsKinTwilightGuardian : Creature
    {
        public SzubsKinTwilightGuardian() : base("Szubs Kin, Twilight Guardian", 5, 6000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
