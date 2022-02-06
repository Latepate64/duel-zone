using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    public class DestroyEffect : CardMovingChoiceEffect
    {
        public DestroyEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Graveyard)
        {
        }

        public DestroyEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "destroy" : "your opponent destroys")} {GetAmountAsText()} {Filter}.";
        }

        public override OneShotEffect Copy()
        {
            return new DestroyEffect(this);
        }
    }
}
