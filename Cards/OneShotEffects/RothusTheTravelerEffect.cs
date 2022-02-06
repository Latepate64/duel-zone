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
            new DestroyEffect(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true).Apply(game, source);
            new DestroyEffect(new CardFilters.OpponentsBattleZoneCreatureFilter(), 1, 1, false).Apply(game, source);
        }

        public override OneShotEffect Copy()
        {
            return new RothusTheTravelerEffect();
        }

        public override string ToString()
        {
            return "destroy one of your creatures. Then your opponent chooses one of his creatures and destroys it.";
        }
    }
}