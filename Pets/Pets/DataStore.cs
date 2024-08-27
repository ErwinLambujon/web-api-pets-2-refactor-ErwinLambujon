namespace Pets
{
    public class DataStore
    {
        public List<Pet> Pets = new List<Pet>
        {
            new() { Id = 1, Name = "Ezreal", Birthdate = DateTime.Now, OwnerId = 1 },
            new() { Id = 2, Name = "Seraphine", Birthdate = DateTime.Now , OwnerId = 2},
            new() { Id = 3, Name = "Varus", Birthdate = DateTime.Now , OwnerId = 2},
        };

        public List<Owner> Owners = new List<Owner>
        {
            new Owner() { Id = 1, Name = "Jhon" },
            new Owner() { Id = 2, Name = "Samuel" }
        };
    }
}
