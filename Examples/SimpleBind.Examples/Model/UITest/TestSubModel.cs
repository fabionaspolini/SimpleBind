namespace SimpleBind.Examples.Model.UITest
{
    public class TestSubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Id + " - " + Name;
        }

        private static TestSubModel[] _all;
        public static TestSubModel[] GetAll()
        {
            return _all ?? (_all = new[]
            {
                new TestSubModel {Id = 1, Name = "Car"},
                new TestSubModel {Id = 2, Name = "Motorcycle"},
                new TestSubModel {Id = 3, Name = "Boat"},
                new TestSubModel {Id = 4, Name = "Airplane"},
                new TestSubModel {Id = 5, Name = "Submarine"}
            });
        }
    }
}
