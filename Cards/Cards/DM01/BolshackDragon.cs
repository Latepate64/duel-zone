using Cards.CardFilters;
using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class BolshackDragon : Creature
    {
        public BolshackDragon() : base("Bolshack Dragon", 6, 6000, Common.Subtype.ArmoredDragon, Common.Civilization.Fire)
        {
            // While attacking, this creature gets +1000 power for each fire card in your graveyard.
            AddAbilities(new StaticAbility(new PowerAttackerMultiplierEffect(1000, new OwnersGraveyardCardFilter(Common.Civilization.Fire))), new DoubleBreakerAbility());
        }
    }
}