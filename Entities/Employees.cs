namespace Entities
{
    public class Root
    {
        public string status { get; set; }
        public List<Employees> data { get; set; }
        public string message { get; set; }
    }

    public class Employees
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public double employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
        public double employee_anual_salary { get; set; }
    }
}