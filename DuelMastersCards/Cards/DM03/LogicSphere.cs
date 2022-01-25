using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards.DM03
{
    class LogicSphere : Spell
    {
        public LogicSphere() : base("Logic Sphere", 3, Civilization.Light)
        {
            ShieldTrigger = true;

            // Return a spell from your mana zone to your hand.
            Abilities.Add(new SpellAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneSpellFilter(), 1, 1, true)));
        }
    }
}
