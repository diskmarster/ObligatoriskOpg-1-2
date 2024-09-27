namespace ClassLibrary___Til_ObligatoriskOpg
{
    public class Trophy
    {
        private int _id;
        private string _competition;
        private int _year;
        // Jeg bruger _ foran mine variabler for at indikere at det er en privat variabel da det forhindre selvhenvisning som var med til at skabe problemer når jeg skulle teste min kode.
        public int Id { get; set; }
        public string Competition { get; set; }
        public int Year { get; set; }

        public void validateID()
        {  
            if (Id < 0)// her siger jeg det skal være et enkelt tal og det skal være større end 0, alternativ kunne jeg have sagt det skulle være et single digit tal ved at skrive: if (value >= 0 && value <= 9)
            {
                throw new ArgumentOutOfRangeException("ID must be a non-negative integer.");
            }
        }


        public void validateCompetition()
        {
            if (string.IsNullOrEmpty(Competition) || Competition.Length < 3) // Her siger jeg at Competition ikke må være null og at det skal være mindst 3 karakterer langt.
            {
                throw new ArgumentOutOfRangeException("Competition cannot be null and must be at least 3 characters long.");
            }
        }

        

        public void validateYear()
        {
            if (Year < 1970 || Year > 2024) // Her siger jeg at Year skal være mellem 1970 og 2024.
            {
                throw new ArgumentOutOfRangeException("Year must be between 1970 and 2024.");
            }
        }

        public override string ToString()
        {
            return $"ID: {Id}, Competition: {Competition}, Year: {Year}";
        }
    }
}
