namespace Engine.ContinuousEffects
{
    public interface IPlayerCannotTapCreatureEffect : IContinuousEffect
    {
        bool PlayerCannotTapCreature(IPlayer player, ICard creature);
    }
}
