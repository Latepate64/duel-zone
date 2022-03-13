using Cards.ContinuousEffects;
using Common;
using Common.Choices;
using Common.GameEvents;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM07
{
    class AquaAgent : Creature
    {
        public AquaAgent() : base("Aqua Agent", 6, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            //TODO: Water stealth
            // When this creature would be destroyed, you may return it to your hand instead.
            AddAbilities(new StaticAbility(new AquaAgentAbilityEffect()));
        }
    }

    class AquaAgentAbilityEffect : DestructionReplacementEffect
    {
        public AquaAgentAbilityEffect() : base()
        {
        }

        public AquaAgentAbilityEffect(AquaAgentAbilityEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new AquaAgentAbilityEffect(this);
        }

        public override bool Apply(Engine.Game game, Engine.Player player)
        {
            if (player.Choose(new YesNoChoice(player.Id, ToString()), game).Decision)
            {
                game.Move(ZoneType.BattleZone, ZoneType.Hand, GetAffectedCards(game).ToArray());
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString() + "you may return it to your hand instead.";
        }
    }
}
