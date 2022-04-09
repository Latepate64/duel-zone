using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class BallomMasterOfDeath : EvolutionCreature
    {
        public BallomMasterOfDeath() : base("Ballom, Master of Death", 8, 12000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new BallomMasterOfDeathEffect());
            AddDoubleBreakerAbility();
        }
    }

    class BallomMasterOfDeathEffect : OneShotEffects.DestroyAreaOfEffect
    {
        public BallomMasterOfDeathEffect() : base(new CardFilters.BattleZoneNonCivilizationCreatureFilter(Civilization.Darkness))
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

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.Creatures.Where(x => !x.HasCivilization(Civilization.Darkness));
        }
    }
}
