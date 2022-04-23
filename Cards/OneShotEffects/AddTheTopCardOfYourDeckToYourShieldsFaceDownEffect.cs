using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect : OneShotEffect
    {
        public AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect()
        {
        }

        public AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            Controller.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect(this);
        }

        public override string ToString()
        {
            return "Add the top card of your deck to your shields face down.";
        }
    }
}