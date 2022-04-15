using Cards.OneShotEffects;

namespace Cards.Cards.DM02
{
    class MagrisVizierOfMagnetism : Creature
    {
        public MagrisVizierOfMagnetism() : base("Magris, Vizier of Magnetism", 4, 3000, Engine.Subtype.Initiate, Common.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawCardsEffect(1));
        }
    }
}
