using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.Static
{
    public class SpellShieldTrigger : StaticAbilityForSpell
    {
        public SpellShieldTrigger(Spell spell) : base(new Effects.ContinuousEffects.SpellShieldTriggerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetSpellFilter(spell)), StaticAbilityForSpellActivityCondition.WhileThisSpellIsInYourHand)
        { }
    }
}
