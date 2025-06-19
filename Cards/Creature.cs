using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards
{
    class Creature : Engine.Creature
    {
        protected Creature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : base(
            tapped: false, [.. civilizations], manaCost, summoningSickness: true, power, name, [race])
        {
        }

        protected Creature(string name, int manaCost, int power, List<Race> races, params Civilization[] civilizations)
            : base(tapped: false, [.. civilizations], manaCost, summoningSickness: true, power, name, races)
        {
        }

        #region Static abilities
        protected void AddBlockerAbility()
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }

        protected void AddThisCreatureCannotAttackAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }

        protected void AddSlayerAbility()
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }

        protected void AddPowerAttackerAbility(int power)
        {
            AddStaticAbilities(new PowerAttackerEffect(power));
        }

        protected void AddThisCreatureCannotBeBlockedAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }

        protected void AddDoubleBreakerAbility()
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }

        protected void AddTripleBreakerAbility()
        {
            AddStaticAbilities(new TripleBreakerEffect());
        }

        protected void AddThisCreatureCannotAttackPlayersAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }

        protected void AddThisCreatureCanAttackUntappedCreaturesAbility()
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        }

        protected void AddSpeedAttackerAbility()
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
        }

        protected void AddThisCreatureCannotBeAttackedAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
        }

        protected void AddThisCreatureBlocksIfAble()
        {
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
        }
        #endregion Static abilities

        #region Triggered abilities
        protected void AddTriggeredAbility(ITriggeredAbility ability)
        {
            AddAbilities(ability);
        }

        protected void AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(effect));
        }

        protected void AddAtTheEndOfYourTurnAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(effect));
        }

        protected void AddWheneverThisCreatureAttacksAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(effect));
        }

        protected void AddWhenThisCreatureIsDestroyedAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(effect));
        }
        #endregion Triggered abilities

        protected void AddTapAbility(IOneShotEffect effect)
        {
            AddAbilities(new TapAbility(effect));
        }

        protected void AddSurvivorAbility(Engine.ContinuousEffects.IContinuousEffect effect)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(effect)));
        }

        protected void AddSurvivorAbility(ITriggeredAbility ability)
        {
            AddStaticAbilities(new SurvivorEffect(ability));
        }
    }
}
