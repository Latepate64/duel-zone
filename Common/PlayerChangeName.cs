namespace Common
{
    public class PlayerChangeName
    {
        public Player Player { get; set; }

        public override string ToString()
        {
            return $"{Player.Id} set their name as {Player}.";
        }
    }
}
