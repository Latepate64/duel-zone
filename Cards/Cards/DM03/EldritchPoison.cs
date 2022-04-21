using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class EldritchPoison : Spell
    {
        public EldritchPoison() : base("Eldritch Poison", 1, Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new EldritchPoisonEffect());
        }
    }

    class EldritchPoisonEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var controller = GetController(game);
            var creature = controller.ChooseControlledCreatureOptionally(game, ToString(), Civilization.Darkness);
            if (creature != null)
            {
                game.Destroy(GetSourceAbility(game), creature);
                controller.ReturnOwnManaCreature(game, GetSourceAbility(game));
            }
        }

        public override IOneShotEffect Copy()
        {
            return new EldritchPoisonEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your darkness creatures. If you do, return a creature from your mana zone to your hand.";
        }
    }
}
