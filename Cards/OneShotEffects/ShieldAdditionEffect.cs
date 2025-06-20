using OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class ShieldAdditionEffect : CardSelectionEffect<Card>
    {
        protected ShieldAdditionEffect(ShieldAdditionEffect effect) : base(effect)
        {
        }

        protected ShieldAdditionEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses)
        {
        }

        protected override void Apply(IGame game, IAbility source, params Card[] cards)
        {
            game.Move(Ability, ZoneType.Hand, ZoneType.ShieldZone, cards);
        }
    }
}
