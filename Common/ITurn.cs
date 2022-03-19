namespace Common
{
    public interface ITurn : IIdentifiable
    {
        
        int Number { get; set; }

        string ToString();
    }
}