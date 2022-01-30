using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM01
{
    class FatalAttackerHorvath : Creature
    {
        public FatalAttackerHorvath() : base("Fatal Attacker Horvath", 3, Civilization.Fire, 2000, Subtype.Human)
        {
            // While you have at least 1 Armorloid in the battle zone, this creature gets +2000 power during its attacks.
            Abilities.Add(new StaticAbility(new PowerModifyingEffect(new ArmoredWalkerUrherionFilter(Subtype.Armorloid), 2000, new Indefinite())));
        }
    }
}
