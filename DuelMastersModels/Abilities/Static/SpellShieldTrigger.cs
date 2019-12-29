using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.Static
{
    internal class SpellShieldTrigger : StaticAbilityForSpell
    {
        internal SpellShieldTrigger(Spell spell) : base(new Effects.ContinuousEffects.SpellShieldTriggerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetSpellFilter(spell)), StaticAbilityForSpellActivityCondition.WhileThisSpellIsInYourHand)
        { }
    }
}
