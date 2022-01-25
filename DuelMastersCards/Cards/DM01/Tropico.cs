using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    class Tropico : Creature
    {
        public Tropico() : base("Tropico", 5, Civilization.Water, 3000, Subtype.CyberLord)
        {
            // This creature can't be blocked while you have at least 2 other creatures in the battle zone.
            Abilities.Add(new StaticAbility(new ContinuousEffects.TropicoEffect()));
        }
    }
}
