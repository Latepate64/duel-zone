using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class VolcanicArrows : Spell
    {
        public VolcanicArrows() : base("Volcanic Arrows", 2, Civilization.Fire)
        {
            ShieldTrigger = true;

            // Destroy a creature that has power 6000 or less.
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureEffect(new CreaturesWithMaxPowerFilter(6000))));

            // Choose one of your shields and put it into your graveyard.
            Abilities.Add(new SpellAbility(new PutOwnShieldToGraveyardEffect()));
        }
    }
}
