using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class MarineFlower : Creature
    {
        public MarineFlower() : base("Marine Flower", 1, 2000, Common.Subtype.CyberVirus, Common.Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
