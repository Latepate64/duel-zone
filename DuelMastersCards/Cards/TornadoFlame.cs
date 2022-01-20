using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class TornadoFlame : Spell
    {
        public TornadoFlame() : base("Tornado Flame", 5, Civilization.Fire)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureEffect(new CreaturesWithMaxPowerFilter(4000))));
        }
    }
}
