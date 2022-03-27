using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect : OneShotEffect
    {
        public AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect()
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.GetPlayer(source.Owner).PutFromTopOfDeckIntoShieldZone(1, game);
            return null;
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