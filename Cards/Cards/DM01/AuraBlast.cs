using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class AuraBlast : Spell
    {
        public AuraBlast() : base("Aura Blast", 4, Common.Civilization.Nature)
        {
            // Each of your creatures in the battle zone gets "power attacker +2000" until the end of the turn. (While attacking, a creature that has "power attacker +2000" gets +2000 power.)
            Abilities.Add(new SpellAbility(new AuraBlastEffect()));
        }
    }
}
