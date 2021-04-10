using DuelMastersModels.Abilities.TriggerAbilities;
using DuelMastersModels.Effects.OneShotEffects;

namespace DuelMastersModels.Cards.Creatures
{
    public class AquaHulcus : Creature
    {
        public AquaHulcus() : base(3, Civilization.Water, 2000, Race.LiquidPeople)
        {
            TriggerAbilities.Add(new TriggerAbility(new WhenYouPutThisCreatureIntoTheBattleZone(), new YouMayDrawACardEffect()));
        }
    }
}
