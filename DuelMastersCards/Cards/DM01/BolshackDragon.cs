using DuelMastersCards.CardFilters;
using DuelMastersCards.ContinuousEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards.DM01
{
    public class BolshackDragon : Creature
    {
        public BolshackDragon() : base("Bolshack Dragon", 6, Civilization.Fire, 6000, Subtype.ArmoredDragon)
        {
            // While attacking, this creature gets +1000 power for each fire card in your graveyard.
            var filter = new OwnersGraveyardCardFilter();
            filter.Civilizations.Add(Civilization.Fire);
            Abilities.Add(new StaticAbility(new BolshackDragonEffect(filter)));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}