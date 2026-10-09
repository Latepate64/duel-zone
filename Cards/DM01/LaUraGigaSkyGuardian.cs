using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM01
{
    sealed class LaUraGigaSkyGuardian : Creature
    {
        public LaUraGigaSkyGuardian() : base("La Ura Giga, Sky Guardian", 1, 2000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
