using TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class RumblingTerahorn : Engine.Creature
    {
        public RumblingTerahorn() : base("Rumbling Terahorn", 5, 3000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchCreatureEffect()));
        }
    }
}
