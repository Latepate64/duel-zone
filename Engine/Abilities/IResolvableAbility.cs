namespace Engine.Abilities
{
    public interface IResolvableAbility : IAbility
    {
        IOneShotEffect OneShotEffect { get; set; }

        void Resolve(IGame game);
    }
}