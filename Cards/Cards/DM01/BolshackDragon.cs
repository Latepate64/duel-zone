using Cards.ContinuousEffects;
using Effects.Continuous;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class BolshackDragon : Creature
    {
        public BolshackDragon() : base("Bolshack Dragon", 6, 6000, Race.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new BolshackDragonEffect(), new DoubleBreakerEffect());
        }
    }

    class BolshackDragonEffect(int power = 1000) : PowerAttackerMultiplierEffect(power)
    {
        public override IContinuousEffect Copy()
        {
            return new BolshackDragonEffect();
        }

        public override string ToString()
        {
            return $"While attacking, this creature gets +{Power} power for each fire card in your graveyard.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return Controller.Graveyard.GetCardCount(Civilization.Fire);
        }
    }
}