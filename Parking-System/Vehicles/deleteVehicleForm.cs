﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_System
{
    public partial class deleteVehicleForm : Form
    {
        public deleteVehicleForm()
        {
            InitializeComponent();
        }

        private void deleteVehicleForm_Load(object sender, EventArgs e)
        {
            comboBoxID.DataSource = vehicle.getVehicle(new SqlCommand("SELECT MaTheXe FROM Xe"));
            comboBoxID.ValueMember = "MaTheXe";
            comboBoxID.ValueMember = "MaTheXe";
            comboBoxID_SelectionChangeCommitted(sender, e);
        }

        Vehicle vehicle = new Vehicle();

        private void comboBoxID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT MaTheXe, LoaiXe, ThoiGianVao, AnhXe FROM Xe WHERE MaTheXe = " + comboBoxID.Text);

            DataTable table = vehicle.getVehicle(command);

            if (table.Rows.Count > 0)
            {
                labelCardID.Text = table.Rows[0]["MaTheXe"].ToString();
                labelTypeOfVehicle.Text = table.Rows[0]["LoaiXe"].ToString();
                labelInTime.Text = table.Rows[0]["ThoiGianVao"].ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
