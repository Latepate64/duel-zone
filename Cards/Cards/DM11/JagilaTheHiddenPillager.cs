using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class JagilaTheHiddenPillager : WaveStrikerCreature
    {
        public JagilaTheHiddenPillager() : base("Jagila, the Hidden Pillager", 5, 3000, Engine.Race.PandorasBox, Engine.Civilization.Darkness)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new JagilaEffect()));
        }
    }

    class JagilaEffect : OpponentRandomDiscardEffect
    {
        public JagilaEffect() : base(3)
        {
        }

        public JagilaEffect(OpponentRandomDiscardEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new JagilaEffect(this);
        }
    }
}
