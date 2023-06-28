using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class ShieldAdditionEffect : CardSelectionEffect
    {
        protected ShieldAdditionEffect(ShieldAdditionEffect effect) : base(effect)
        {
        }

        protected ShieldAdditionEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses)
        {
        }

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            Game.Move(Ability, ZoneType.Hand, ZoneType.ShieldZone, cards);
        }
    }
}
