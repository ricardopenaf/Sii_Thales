using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Business
{

    public class EmployeeBusiness
    {
        public string url = "http://dummy.restapiexample.com/";

        public async Task<List<Employees>> listEmployees()
        {
            List<Employees> employee = new List<Employees>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/v1/employees");
                if (Res.IsSuccessStatusCode)
                {
                    var record = Res.Content.ReadAsStringAsync().Result;
                    Root objResponse = JsonConvert.DeserializeObject<Root>(record);
                    employee = objResponse.data;

                }

                return employee;
            }
        }

        public async Task<List<Employees>> GetEmployeeId(int? Id)
        {
            List<Employees> employeeId = new List<Employees>();

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/v1/employee/" + Id.ToString());
                    if (Res.IsSuccessStatusCode)
                    {
                        var record = Res.Content.ReadAsStringAsync().Result;
                        dynamic employee = JsonConvert.DeserializeObject(record);
                       
                        employeeId.Add(new Employees
                        {
                            id = employee.data.id,
                            employee_name = employee.data.employee_name,
                            employee_salary = employee.data.employee_salary,
                            employee_age = employee.data.employee_age,
                            profile_image = employee.data.profile_image
                        });
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return employeeId;
        }

        public List<Employees> AnnualSalary(List<Employees> employee)
        {
            var annualSalary = new List<Employees>();
            foreach (var salary in employee)
            {
                annualSalary.Add(new Employees
                {
                    id = salary.id,
                    employee_name = salary.employee_name,
                    employee_salary = salary.employee_salary,
                    employee_age = salary.employee_age,
                    profile_image = salary.profile_image,
                    employee_anual_salary = (salary.employee_salary * 12)
                });
            }
            return annualSalary;
        }

    }
}