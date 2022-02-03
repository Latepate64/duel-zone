using Cards.CardFilters;
using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    public class BolshackDragon : Creature
    {
        public BolshackDragon() : base("Bolshack Dragon", 6, Common.Civilization.Fire, 6000, Common.Subtype.ArmoredDragon)
        {
            // While attacking, this creature gets +1000 power for each fire card in your graveyard.
            var filter = new OwnersGraveyardCardFilter();
            filter.Civilizations.Add(Common.Civilization.Fire);
            Abilities.Add(new StaticAbility(new BolshackDragonEffect(filter)));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}