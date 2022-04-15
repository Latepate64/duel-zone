using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.Cards.DM06
{
    class FrostSpecterShadowOfAge : EvolutionCreature
    {
        public FrostSpecterShadowOfAge() : base("Frost Specter, Shadow of Age", 3, 5000, Engine.Subtype.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new FrostSpecterShadowOfAgeEffect());
        }
    }

    class FrostSpecterShadowOfAgeEffect : AbilityAddingEffect
    {
        public FrostSpecterShadowOfAgeEffect() : base(new StaticAbilities.SlayerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new FrostSpecterShadowOfAgeEffect();
        }

        public override string ToString()
        {
            return "Each of your Ghosts in the battle zone has \"slayer.\"";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(GetController(game).Id, Engine.Subtype.Ghost);
        }
    }
}
