namespace VjezbaLinq
{
    internal class Igrac
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public string Igra { get; set; }
        public int HoursPlayed { get; set; }

        public Igrac(string name, int id, int age, string igra, int hoursPlayed)
        {
            Name = name;
            Id = id;
            Age = age;
            Igra = igra;
            HoursPlayed = hoursPlayed;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Id: {Id}, Age: {Age}, Game: {Igra}, Hours played: {HoursPlayed}";
        }
    }
}