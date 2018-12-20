namespace StorageMaster
{
    using StorageMaster.Core;

    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine(new StorageMaster());
            engine.Run();
        }
    }
}
