using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class NaturalSnare : Spell
    {
        public NaturalSnare() : base("Natural Snare", 6, Civilization.Nature)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new NaturalSnareResolvable()));
        }
    }
}
