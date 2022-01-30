using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class MarineFlower : Creature
    {
        public MarineFlower() : base("Marine Flower", 1, Civilization.Water, 2000, Subtype.CyberVirus)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
