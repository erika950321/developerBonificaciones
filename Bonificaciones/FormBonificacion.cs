using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonificaciones
{
    public partial class FormBonificacion : Form
    {
        public FormBonificacion()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            var empleados = new List<string[]>();
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] lineas = File.ReadAllLines(ofd.FileName);

                string[] encabezado = lineas[0].Split(';');
                dgvEmpleados.Columns.Clear();
                foreach (string c in encabezado)
                {
                    dgvEmpleados.Columns.Add(c, c);
                }

                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] celdas = lineas[i].Split(';');
                    if (!celdas[0].Equals(""))
                    {
                        dgvEmpleados.Rows.Add(celdas);
                    }
                    empleados.Add(celdas);
                }
                ListarEmpleados(empleados);
            }
            //btnCargar.Enabled = false;
        }
        private List<string[]> ListarEmpleados(List<string[]> empleados)
        {
            var listaDepurada = new List<string[]>(empleados);
            return listaDepurada;
        }
    }
}
