﻿using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

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
            foreach (var effect in new OneShotEffect[] { new SacrificeEffect(), new OpponentSacrificeEffect() })
            {
                effect.Apply(game, source);
            }
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
