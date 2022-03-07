using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class RothusTheTravelerEffect : OneShotEffect
    {
        public RothusTheTravelerEffect()
        {
        }

        public override void Apply(Game game, Ability source)
        {
            new SacrificeEffect().Apply(game, source);
            new OpponentSacrificeEffect().Apply(game, source);
        }

        public override OneShotEffect Copy()
        {
            return new RothusTheTravelerEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your creatures. Then your opponent chooses one of his creatures and destroys it.";
        }
    }
}