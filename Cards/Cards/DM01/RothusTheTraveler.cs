using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM01
{
    class RothusTheTraveler : Creature
    {
        public RothusTheTraveler() : base("Rothus, the Traveler", 4, 4000, Race.Armorloid, Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new RothusTheTravelerEffect());
        }
    }

    class RothusTheTravelerEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            new List<IPlayer> { source.GetController(game), source.GetOpponent(game) }.ForEach(x => x.Sacrifice(game, source));
        }

        public override IOneShotEffect Copy()
        {
            return new RothusTheTravelerEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your creatures. Then your opponent chooses one of his creatures and destroys it.";
        }
    }
}
