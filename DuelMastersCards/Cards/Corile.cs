using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Corile : Creature
    {
        public Corile() : base("Corile", 5, Civilization.Water, 2000, Subtype.CyberLord)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CorileEffect()));
        }
    }
}
