using TriggeredAbilities;

namespace Cards.DM02
{
    sealed class RumblingTerahorn : Creature
    {
        public RumblingTerahorn() : base("Rumbling Terahorn", 5, 3000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchCreatureEffect()));
        }
    }
}
