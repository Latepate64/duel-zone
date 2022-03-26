using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM03
{
    class SearingWave : Spell
    {
        public SearingWave() : base("Searing Wave", 5, Civilization.Fire)
        {
            AddSpellAbilities(new DestroyAreaOfEffect(new CardFilters.OpponentsBattleZoneMaxPowerCreatureFilter(3000)), new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }
}
