using Abilities.Static;
using ContinuousEffects.Replacement;
using Interfaces;

namespace Cards.DM10
{
    sealed class SanfistTheSavageVizier : Creature
    {
        public SanfistTheSavageVizier() : base("Sanfist, the Savage Vizier", 3, 3000, [Race.BeastFolk, Race.Initiate], Civilization.Light, Civilization.Nature)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new OptionalMadnessEffect());
        }
    }
}
