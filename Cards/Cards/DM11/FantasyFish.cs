using Cards.StaticAbilities;

namespace Cards.Cards.DM11
{
    public class FantasyFish : Creature
    {
        public FantasyFish() : base("Fantasy Fish", 7, Common.Civilization.Water, 2000, Common.Subtype.GelFish)
        {
            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
        }
    }
}
