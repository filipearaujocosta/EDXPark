using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDXPark
{
    public class Vacancy
    {
        public string street;
        public int vacancy;
        public bool available;
        public string plateCar;
        public string plan;

        public Vacancy()
        {

        }

        public Vacancy(string str, int vac, bool avail, string pltCar = "", string planVac= "")
        {
            street = str;
            vacancy = vac;
            available = avail;
            plateCar = pltCar;
            plan = planVac;
        }

        public List<Vacancy> addVacancy()
        {
            List<Vacancy> VacancyList = new List<Vacancy>();
            

            for(int i = 1; i <= 10; i++)
            {
                var vac = new Vacancy(street = "A",i,true, "", (i<=5)? "M":"A");
                //{
                //    street = "A",
                //    vacancy = i,
                //    available = true
                //};
                VacancyList.Add(vac);
            }
            return VacancyList;            
        }
    }
}
