using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    class LaserWhip : Spell
    {
        public LaserWhip() : base("Laser Whip", 4, Civilization.Light)
        {
            AddSpellAbilities(new LaserWhipEffect());
        }
    }

    class LaserWhipEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var controller = source.GetController(game);
            controller.TapOpponentsCreature(game);
            var creature = controller.ChooseControlledCreatureOptionally(game, ToString());
            if (creature != null)
            {
                game.AddContinuousEffects(source, new ChosenCreaturesCannotBeBlockedThisTurnEffect(creature));
            }
        }

        public override IOneShotEffect Copy()
        {
            return new LaserWhipEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and tap it. Then you may choose one of your creatures in the battle zone. If you do, it can't be blocked this turn.";
        }
    }
}
