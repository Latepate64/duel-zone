namespace Common
{
    public class CreateTable
    {
        public Table Table { get; set; }

        public override string ToString()
        {
            return $"{Table.Host} created {Table}.";
        }
    }
}