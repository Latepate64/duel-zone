using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class GalklifeDragon : Creature
    {
        public GalklifeDragon() : base("Galklife Dragon", 7, 6000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GalklifeDragonEffect());
            AddDoubleBreakerAbility();
        }
    }

    class GalklifeDragonEffect : OneShotEffects.DestroyAreaOfEffect
    {
        public GalklifeDragonEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GalklifeDragonEffect();
        }

        public override string ToString()
        {
            return "Destroy all light creatures that have power 4000 or less.";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Civilization.Light).Where(x => x.Power <= 4000);
        }
    }
}
