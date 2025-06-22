using ContinuousEffects;

namespace Cards.DM11
{
    sealed class YulianaChannelerOfSuns : Engine.Creature
    {
        public YulianaChannelerOfSuns() : base("Yuliana, Channeler of Suns", 3, 3000, Interfaces.Race.MechaDelSol, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new OpponentCannotChooseThisCreatureEffect());
        }
    }
}
