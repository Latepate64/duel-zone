using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Emeral : Creature
    {
        public Emeral() : base("Emeral", 2, Civilization.Water, 1000, Subtype.CyberLord)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new EmeralEffect()));
        }
    }
}
