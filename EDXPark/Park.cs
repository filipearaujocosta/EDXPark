using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDXPark
{
    public partial class Park : Form
    {
        List<Vacancy> vList;
        List<Car> cList = new List<Car>();
        public Park()
        {
            InitializeComponent();
            Vacancy vac = new Vacancy();

            vList = vac.addVacancy();

            lbVagas.Text = (10 - vList.Where(x => x.available == false).Count()).ToString() + " Vacancies";
            progressBarVac.Maximum = 10;
            progressBarVac.Value = vList.Where(x => x.available == false).Count();
        }


        private void btParkMain_Click(object sender, EventArgs e)
        {
            var plan = "";
            if (radioButton1.Checked)
            {
                plan = "M";
            }else
            {
                plan = "A";
            }
            Car car = new Car(this.txModelCar.Text, this.txPlateCar.Text, plan);  

            var ret = car.addCar(vList, cList);
            MessageBox.Show(ret, "EDX Park");

            lbVagas.Text = (10 - vList.Where(x => x.available == false).Count()).ToString() + " Vacancies";
            progressBarVac.Value = vList.Where(x => x.available == false).Count();
        }

        private void btBy_Click(object sender, EventArgs e)
        {
            Car car = new Car();          

            var ret = car.removeCar(vList, cList, this.txPlateOut.Text);

            MessageBox.Show(ret, "EDX Park");

            lbVagas.Text = (10 - vList.Where(x => x.available == false).Count()).ToString() + " Vacancies";
            progressBarVac.Value = vList.Where(x => x.available == false).Count();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
