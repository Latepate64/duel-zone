using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class VolcanoCharger : Spell
    {
        public VolcanoCharger() : base("Volcano Charger", 4, Civilization.Fire)
        {
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureEffect(new CreaturesWithMaxPowerFilter(2000))));
            Abilities.Add(new ChargerAbility());
        }
    }
}
