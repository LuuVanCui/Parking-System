using System;
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
    public partial class manageForm : Form
    {
        public manageForm()
        {
            InitializeComponent();
        }
        Vehicle vehicle = new Vehicle();
        private void manageForm_Load(object sender, EventArgs e)
        {
            DataTable dt = vehicle.getTypeVehicle();
            dt.Rows.Add(new Object[]{
                "Tat Ca"
            });
            comboBoxTypeVehicle.DataSource = dt;
            comboBoxTypeVehicle.ValueMember = "LoaiXe";
            comboBoxTypeVehicle.DisplayMember = "LoaiXe";
            fillGrid();
            makeUpGridForXeMayAndXeDap();
        }

       

       

        

        void fillGrid()
        {
            if (comboBoxTypeVehicle.Text == "Xe May")
            {
                dataGridVManageVehicle.DataSource = vehicle.getVehicle(new SqlCommand("SELECT MaTheXe, LoaiXe, NguoiGui, BienSo, ThoiGianVao FROM dbo.Xe WHERE LoaiXe = 'Xe May'"));
                makeUpGridForXeMayAndXeDap();
            }
            else if (comboBoxTypeVehicle.Text == "Xe Dap")
            {
                dataGridVManageVehicle.DataSource = vehicle.getVehicle(new SqlCommand("SELECT MaTheXe, LoaiXe, NguoiGui, AnhXe, ThoiGianVao FROM dbo.Xe WHERE LoaiXe = 'Xe Dap'"));
                makeUpGridForXeMayAndXeDap();
            }
            else if (comboBoxTypeVehicle.Text == "Xe Hoi")
            {
                dataGridVManageVehicle.DataSource = vehicle.getVehicle(new SqlCommand("SELECT MaTheXe, LoaiXe, HieuXe, BienSo, ThoiGianVao FROM Xe  WHERE LoaiXe = 'Xe Hoi'"));
                makeUpGridForXeMayAndXeDap();
            }
            else if (comboBoxTypeVehicle.Text == "Tat Ca")
            {
                dataGridVManageVehicle.DataSource = vehicle.getVehicle(new SqlCommand("SELECT * FROM Xe"));
                makeUpGridForAllAndXeHoi();
            }
            labelStatus.Text = "Total Vehicle: " + dataGridVManageVehicle.Rows.Count.ToString();
        }

       

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addVehicleForm addForm = new addVehicleForm();
            addForm.ShowDialog(this);
        }

        void makeUpGridForAllAndXeHoi()
        {
            try
            {
                dataGridVManageVehicle.ReadOnly = true;

                DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
                DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
                DataGridViewImageColumn picCol4 = new DataGridViewImageColumn();
                DataGridViewImageColumn picCol5 = new DataGridViewImageColumn();


                dataGridVManageVehicle.RowTemplate.Height = 80;

                picCol2 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[2];
                picCol3 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[3];
                picCol4 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[4];
                picCol5 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[5];

                picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
                picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;
                picCol4.ImageLayout = DataGridViewImageCellLayout.Stretch;
                picCol5.ImageLayout = DataGridViewImageCellLayout.Stretch;

                dataGridVManageVehicle.AllowUserToAddRows = false;
            }
            catch
            {

            }
        }

        void makeUpGridForXeMayAndXeDap()
        {
            try
            {
                dataGridVManageVehicle.ReadOnly = true;

                DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
                DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();

                dataGridVManageVehicle.RowTemplate.Height = 80;

                picCol2 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[2];
                picCol3 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[3];

                picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
                picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;

                dataGridVManageVehicle.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       
        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridVManageVehicle.CurrentRow.Cells[0].Value.ToString();
                paymentForm pay = new paymentForm(id);

                pay.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridVManageVehicle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void buttonRefresh_Click_1(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void textBoxSearchLicenPlate_TextChanged_1(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("SELECT * FROM Xe WHERE CONCAT(MaTheXe, LoaiXe, BienSo, ThoiGianVao) LIKE '%" + textBoxSearchLicenPlate.Text + "%'");
            SqlCommand command = new SqlCommand("SELECT * FROM Xe WHERE CONCAT(MaTheXe, LoaiXe,ThoiGianVao) LIKE '%" + textBoxSearchLicenPlate.Text + "%'");
            dataGridVManageVehicle.DataSource = vehicle.getVehicle(command);
        }

        private void buttonEdit_Click_1(object sender, EventArgs e)
        {
            editVehiclesForm editForm = new editVehiclesForm();
            editForm.ShowDialog(this);
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridVManageVehicle.CurrentRow.Cells[0].Value.ToString();
                if (MessageBox.Show("Do you want to detele this vehicle", "Delete Vehicle", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    vehicle.deleteVehicle(id);
                    fillGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Vehicle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxTypeVehicle_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            fillGrid();
        }
    }
}
