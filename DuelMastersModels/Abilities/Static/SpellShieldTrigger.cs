using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class SpellShieldTrigger : StaticAbilityForSpell
    {
        internal SpellShieldTrigger(Spell spell, Card source) : base(new Effects.ContinuousEffects.SpellShieldTriggerEffect(new Effects.Periods.Indefinite(), new CardFilters.TargetSpellFilter(spell)), StaticAbilityForSpellActivityCondition.WhileThisSpellIsInYourHand, source)
        { }

        public override Ability Copy()
        {
            throw new System.NotImplementedException();
        }
    }
}
