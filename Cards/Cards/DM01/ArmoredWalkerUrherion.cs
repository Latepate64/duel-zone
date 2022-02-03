using Cards.CardFilters;
using Common;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM01
{
    class ArmoredWalkerUrherion : Creature
    {
        public ArmoredWalkerUrherion() : base("Armored Walker Urherion", 4, Common.Civilization.Fire, 3000, Common.Subtype.Armorloid)
        {
            // While you have at least 1 Human in the battle zone, this creature gets +2000 power during its attacks.
            Abilities.Add(new StaticAbility(new PowerModifyingEffect(new ArmoredWalkerUrherionFilter(Common.Subtype.Human), 2000, new Indefinite())));
        }
    }
}
