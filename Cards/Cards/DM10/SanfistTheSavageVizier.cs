using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM10
{
    class SanfistTheSavageVizier : Creature
    {
        public SanfistTheSavageVizier() : base("Sanfist, the Savage Vizier", 3, 3000, Race.BeastFolk, Race.Initiate, Civilization.Light, Civilization.Nature)
        {
            AddBlockerAbility();
            AddStaticAbilities(new OptionalMadnessEffect());
        }
    }
}
