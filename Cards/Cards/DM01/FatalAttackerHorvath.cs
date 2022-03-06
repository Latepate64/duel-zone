using Cards.CardFilters;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM01
{
    class FatalAttackerHorvath : Creature
    {
        public FatalAttackerHorvath() : base("Fatal Attacker Horvath", 3, 2000, Common.Subtype.Human, Common.Civilization.Fire)
        {
            // While you have at least 1 Armorloid in the battle zone, this creature gets +2000 power during its attacks.
            Abilities.Add(new StaticAbility(new PowerModifyingEffect(new ArmoredWalkerUrherionFilter(Common.Subtype.Armorloid), 2000, new Indefinite())));
        }
    }
}
