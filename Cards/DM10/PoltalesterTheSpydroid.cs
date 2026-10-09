using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM10
{
    sealed class PoltalesterTheSpydroid : Creature
    {
        public PoltalesterTheSpydroid() : base("Poltalester, the Spydroid", 5, 2000, Interfaces.Race.Soltrooper, Interfaces.Civilization.Light)
        {
            AddShieldTrigger();
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
