using Abilities.Static;
using ContinuousEffects;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM11
{
    sealed class YulianaChannelerOfSuns : Creature
    {
        public YulianaChannelerOfSuns() : base("Yuliana, Channeler of Suns", 3, 3000, Interfaces.Race.MechaDelSol, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new OpponentCannotChooseThisCreatureEffect());
        }
    }
}
