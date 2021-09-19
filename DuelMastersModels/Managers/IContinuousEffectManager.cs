using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using System.Collections.Generic;

namespace DuelMastersModels.Managers
{
    public interface IContinuousEffectManager
    {
        Duel Duel { get; set; }
        IAbilityManager AbilityManager { get; set; }

        void AddContinuousEffect(IContinuousEffect continuousEffect);
        bool AttacksIfAble(Creature creature);
        void EndContinuousEffects<T>();
        IEnumerable<Creature> GetAllBlockersPlayerHasInTheBattleZone(IPlayer player);
        IEnumerable<Creature> GetCreaturesThatCannotAttack(IPlayer player);
        IEnumerable<Creature> GetCreaturesThatCannotAttackPlayers();
        int GetPower(Creature creature);
        bool HasShieldTrigger(Creature creature);
        bool HasShieldTrigger(Spell spell);
        bool HasSpeedAttacker(Creature creature);
    }
}