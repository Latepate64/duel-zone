using Common;

namespace Cards.Cards.DM03
{
    class SundropArmor : Spell
    {
        public SundropArmor() : base("Sundrop Armor", 4, Civilization.Light)
        {
            AddAbilities(new Engine.Abilities.SpellAbility(new OneShotEffects.ShieldAdditionEffect(new CardFilters.OwnersHandCardFilter(), 1, 1, true)));
        }
    }
}
