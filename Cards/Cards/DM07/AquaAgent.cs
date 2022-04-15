using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class AquaAgent : Creature
    {
        public AquaAgent() : base("Aqua Agent", 6, 2000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddStaticAbilities(new StealthEffect(Civilization.Water), new AquaAgentEffect());
        }
    }

    class AquaAgentEffect : DestructionReplacementOptionallyToHandEffect
    {
        public AquaAgentEffect() : base() { }


        public override IContinuousEffect Copy()
        {
            return new AquaAgentEffect();
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, you may return it to your hand instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }
    }
}
