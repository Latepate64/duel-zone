using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class SwampWorm : Creature
    {
        public SwampWorm() : base("Swamp Worm", 7, 2000, Engine.Subtype.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentSacrificeEffect());
        }
    }
}
