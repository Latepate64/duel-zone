using Common;
using Engine.Abilities;

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
        public SearingWaveEffect() : base(new CardFilters.OpponentsBattleZoneMaxPowerCreatureFilter(3000))
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
    }
}
