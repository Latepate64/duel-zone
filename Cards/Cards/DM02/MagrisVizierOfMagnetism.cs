using Cards.OneShotEffects;

namespace Cards.Cards.DM02
{
    class MagrisVizierOfMagnetism : Creature
    {
        public MagrisVizierOfMagnetism() : base("Magris, Vizier of Magnetism", 4, 3000, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawCardEffect());
        }
    }
}
