using Cards.OneShotEffects;

namespace Cards.Cards.DM12
{
    class Gigabalza : Creature
    {
        public Gigabalza() : base("Gigabalza", 4, 1000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentDiscardsCardAtRandomEffect());
        }
    }
}
