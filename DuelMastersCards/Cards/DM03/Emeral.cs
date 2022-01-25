using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Emeral : Creature
    {
        public Emeral() : base("Emeral", 2, Civilization.Water, 1000, Subtype.CyberLord)
        {
            // When you put this creature into the battle zone, you may add a card from your hand to your shields face down. If you do, choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new EmeralEffect()));
        }
    }
}
