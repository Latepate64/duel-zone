using Cards.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class YulianaChannelerOfSuns : Engine.Creature
    {
        public YulianaChannelerOfSuns() : base("Yuliana, Channeler of Suns", 3, 3000, Engine.Race.MechaDelSol, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new OpponentCannotChooseThisCreatureEffect());
        }
    }
}
