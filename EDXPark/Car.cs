using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EDXPark
{
    class Car
    {
        private string modelCar;
        private string plateCar;
        private string planCar;

        public Car()
        {
           
        }

        public Car(string model, string plate, string plan)
        {
            modelCar = model;
            plateCar = plate;
            planCar = plan;
        }
        public string addCar(List<Vacancy> vacancyList, List<Car> carList)
        {
            var reg = @"([A-Z]([A-Z])([A-Z]))\-(\d\d\d\d)";
            Regex rgx = new Regex(reg, RegexOptions.IgnoreCase);
            Match m = rgx.Match(plateCar);

            if (!m.Success) {
                return "unknown plate";
            }

            if(vacancyList.Exists(x => x.plateCar == plateCar))
            {
                return $"Este carro com placa {plateCar} ja está estacionado!";
            }

            foreach (var vac in vacancyList)
            {
                if (vac.available == true && vac.plan == planCar)
                {                  
                    vac.available = false;
                    vac.plateCar = plateCar;

                    carList.Add(this);

                    return $"Welcome, {modelCar}";
                }
            }

            return "Full Parking";
        }
        public string removeCar(List<Vacancy> VacancyList, List<Car> carList, string plateOut)
        {           
            carList.Remove(carList.Find(x => x.modelCar == plateOut));
            var v = VacancyList.Find(x => x.plateCar == plateOut);
            if (v != null)
            {
                v.available = true;
                v.plateCar = "";
                return "See You. Bye !!";
            }
            else
            {
                return "Unknown plate";
            }          
        }
    }
}
