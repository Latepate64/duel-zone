using TriggeredAbilities;
using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM03
{
    class AquaDeformer : Engine.Creature
    {
        public AquaDeformer() : base("Aqua Deformer", 8, 3000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaDeformerEffect()));
        }
    }

    class AquaDeformerEffect : MutualManaRecoveryEffect
    {
        public AquaDeformerEffect() : base(1)
        {
        }

        public AquaDeformerEffect(MutualManaRecoveryEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AquaDeformerEffect(this);
        }

        public override string ToString()
        {
            return "When you put this creature into the battle zone, return 2 cards from your mana zone to your hand. Then your opponent chooses 2 cards in his mana zone and returns them to his hand.";
        }
    }
}
