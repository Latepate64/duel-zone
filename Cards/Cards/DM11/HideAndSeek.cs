using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class HideAndSeek : Spell
    {
        public HideAndSeek() : base("Hide and Seek", 4, Civilization.Water, Civilization.Darkness)
        {
            AddSpellAbilities(new HideAndSeekEffect());
        }
    }

    class HideAndSeekEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var controller = source.GetController(game);
            var creature = controller.ChooseOpponentsNonEvolutionCreature(game, ToString());
            game.Move(source, ZoneType.BattleZone, ZoneType.Hand, creature);
            game.GetOpponent(controller).DiscardAtRandom(game, 1, source);
        }

        public override IOneShotEffect Copy()
        {
            return new HideAndSeekEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's non-evolution creatures in the battle zone and return it to his hand. Then he discards a card at random from his hand.";
        }
    }
}
