namespace Lab_2.Models
{
    public class Birth
    {
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }

        private DateTime currentDate = DateTime.Now;

        public bool IsValid()
        {
            if((Name != null) && (BirthDate < currentDate))
            {
                return true;
            }
            else { return false; }
        }

        public int getAge()
        {
            int age = currentDate.Year - BirthDate.Year;

            if (BirthDate.Date > currentDate.Date.AddYears(-age))
            {
                age--; // Jeśli jeszcze nie było urodziny w bieżącym roku, zmniejsz wiek o 1 rok
            }

            return age;
        }
    }
}
