using Common;

namespace Cards.Cards.DM02
{
    class LostSoul : Spell
    {
        public LostSoul() : base("Lost Soul", 7, Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.DiscardAreaOfEffect(new CardFilters.OpponentsHandCardFilter()));
        }
    }
}
