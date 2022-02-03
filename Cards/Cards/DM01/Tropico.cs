using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class Tropico : Creature
    {
        public Tropico() : base("Tropico", 5, Common.Civilization.Water, 3000, Common.Subtype.CyberLord)
        {
            // This creature can't be blocked while you have at least 2 other creatures in the battle zone.
            Abilities.Add(new StaticAbility(new ContinuousEffects.TropicoEffect()));
        }
    }
}
