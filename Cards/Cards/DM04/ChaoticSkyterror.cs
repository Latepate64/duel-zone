using Cards.ContinuousEffects;
using Engine;
using System.Collections.Generic;

namespace Cards.Cards.DM04
{
    class ChaoticSkyterror : Creature
    {
        public ChaoticSkyterror() : base("Chaotic Skyterror", 5, 4000, Engine.Subtype.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ChaoticSkyterrorEffect());
        }
    }

    class ChaoticSkyterrorEffect : AbilityAddingEffect
    {
        public ChaoticSkyterrorEffect(ChaoticSkyterrorEffect effect) : base(effect)
        {
        }

        public ChaoticSkyterrorEffect() : base(new StaticAbilities.PowerAttackerAbility(4000), new StaticAbilities.DoubleBreakerAbility())
        {
        }

        public override ContinuousEffect Copy()
        {
            return new ChaoticSkyterrorEffect(this);
        }

        public override string ToString()
        {
            return "Each Demon Command in the battle zone has \"power attacker +4000\" and \"double breaker.\"";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(Engine.Subtype.DemonCommand);
        }
    }
}
