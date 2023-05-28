namespace BlazorServerFirstProject.Data
{
    public class DummyDataAccess : IDummyDataAccess
    {
        private int age;

        public DummyDataAccess()
        {
            Random random = new Random();
            age = random.Next(18, 65);
        }
        public int GetUserAge()
        {
            return age;
        }
    }
}
