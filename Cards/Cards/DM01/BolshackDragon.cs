using Cards.CardFilters;
using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class BolshackDragon : Creature
    {
        public BolshackDragon() : base("Bolshack Dragon", 6, 6000, Common.Subtype.ArmoredDragon, Common.Civilization.Fire)
        {
            AddStaticAbilities(new BolshackDragonEffect(), new DoubleBreakerEffect());
        }
    }

    class BolshackDragonEffect : PowerAttackerMultiplierEffect
    {
        public BolshackDragonEffect() : base(1000, new OwnersGraveyardCardFilter(Common.Civilization.Fire))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new BolshackDragonEffect();
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +1000 power for each fire card in your graveyard.";
        }
    }
}