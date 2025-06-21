using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.DM04
{
    class BallomMasterOfDeath : EvolutionCreature
    {
        public BallomMasterOfDeath() : base("Ballom, Master of Death", 8, 12000, Race.DemonCommand, Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BallomMasterOfDeathEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }

    class BallomMasterOfDeathEffect : OneShotEffects.DestroyAreaOfEffect
    {
        public BallomMasterOfDeathEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BallomMasterOfDeathEffect();
        }

        public override string ToString()
        {
            return "Destroy all creatures except darkness creatures.";
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.Creatures.Where(x => !x.HasCivilization(Civilization.Darkness));
        }
    }
}
