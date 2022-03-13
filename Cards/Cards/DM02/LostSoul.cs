using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class LostSoul : Spell
    {
        public LostSoul() : base("Lost Soul", 7, Civilization.Darkness)
        {
            AddAbilities(new SpellAbility(new OneShotEffects.DiscardAreaOfEffect(new CardFilters.OpponentsHandCardFilter())));
        }
    }
}
