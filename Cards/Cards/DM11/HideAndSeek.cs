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
        public HideAndSeekEffect()
        {
        }

        public HideAndSeekEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var creature = Applier.ChooseOpponentsNonEvolutionCreature(ToString());
            game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, creature);
            Applier.Opponent.DiscardAtRandom(1, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new HideAndSeekEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's non-evolution creatures in the battle zone and return it to his hand. Then he discards a card at random from his hand.";
        }
    }
}
