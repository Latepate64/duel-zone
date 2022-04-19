using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect : OneShotEffect
    {
        public AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect()
        {
        }

        public override void Apply(IGame game, IAbility source)
        {
            source.GetController(game).PutFromTopOfDeckIntoShieldZone(1, game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect();
        }

        public override string ToString()
        {
            return "Add the top card of your deck to your shields face down.";
        }
    }
}