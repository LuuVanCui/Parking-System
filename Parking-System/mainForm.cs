﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_System
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void manageVerhicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manageVehiclesForm manageForm = new manageVehiclesForm();
            manageForm.Show(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printVehiclesForm printForm = new printVehiclesForm();
            printForm.Show(this);
        }

        private void addVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addVehicleForm addForm = new addVehicleForm();
            addForm.Show(this);
        }

        private void deleteVehicleByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteVehicleByID deleteForm = new deleteVehicleByID();
            deleteForm.Show(this);
        }

        private void staToolStripMenuItem_Click(object sender, EventArgs e)
        {
            staticsForm stf = new staticsForm();
            stf.ShowDialog();
        }

        private void vehicleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vehiclesListForm list = new vehiclesListForm();
            list.ShowDialog();
        }

        private void editVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editVehiclesForm editForm = new editVehiclesForm();
            editForm.Show(this);
        }
    }
}
