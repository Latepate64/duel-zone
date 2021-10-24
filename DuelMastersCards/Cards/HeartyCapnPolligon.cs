using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class HeartyCapnPolligon : Creature
    {
        public HeartyCapnPolligon() : base("Hearty Cap'n Polligon", 1, Civilization.Nature, 2000, Subtype.SnowFaerie)
        {
            Abilities.Add(new HeartyCapnPolligonAbility(new HeartyCapnPolligonResolvable()));
        }
    }
}
