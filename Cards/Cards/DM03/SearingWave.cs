using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class SearingWave : Spell
    {
        public SearingWave() : base("Searing Wave", 5, Civilization.Fire)
        {
            AddSpellAbilities(new SearingWaveEffect(), new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }

    class SearingWaveEffect : OneShotEffects.DestroyAreaOfEffect
    {
        public SearingWaveEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SearingWaveEffect();
        }

        public override string ToString()
        {
            return "Destroy all your opponent's creatures that have power 3000 or less.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Applier.Opponent).Where(x => x.Power <= 3000);
        }
    }
}
