using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class TagtappTheRetaliator : Creature
    {
        public TagtappTheRetaliator() : base("Tagtapp, the Retaliator", 3, 3000, Race.SpiritQuartz, Civilization.Fire, Civilization.Nature)
        {
            AddStaticAbilities(new TagtappTheRetaliatorEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    class TagtappTheRetaliatorEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public TagtappTheRetaliatorEffect(int power = 1000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TagtappTheRetaliatorEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each water card in your opponent's mana zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.GetPlayer(game.GetOpponent(Applier.Id)).ManaZone.GetCards(Civilization.Water).Count();
        }
    }
}
