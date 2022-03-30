using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Acceso_Datos;
using Capa_Entidad;
using Capa_Negocio;


namespace Capa_Presentacion
{
    public partial class Frm : Form
    {
        private string idcategoria;
        private bool editarse = false;

        E_cat objEntidad = new E_cat();
        N_cat objNegocio = new N_cat();

        public string Idcategoria { get => idcategoria; set => idcategoria = value; }

        public Frm()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionTabla();

        }

        public void accionTabla()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 170;

            dataGridView1.ClearSelection();

        }

        public void mostrarBuscarTabla(string Buscar)
        {
            N_cat objNegocio = new N_cat();
            
            dataGridView1.DataSource = objNegocio.ListarCategoria(Buscar);

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            mostrarBuscarTabla(buscartxt.text);
        }

        public void Limpiar()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdesc.Text = "";
            txtnombre.Focus();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editarse = true;
                Idcategoria = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                IDtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtnombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdesc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (editarse == false)
            {
                try
                {
                    objEntidad.Nombre = txtnombre.Text.ToUpper();
                    objEntidad.Descripcion = txtdesc.Text.ToUpper();

                    objNegocio.InsertarCategoria(objEntidad);
                    MessageBox.Show("Registro agregado satsfactoriamente");
                    mostrarBuscarTabla("");
                    Limpiar();
                }
                catch(Exception ex) {
                    MessageBox.Show("El registro no se ha agregado correctamente" + ex);
                }
            }
            if (editarse==true)
            {
                try
                {
                    objEntidad.Idcategoria = Convert.ToInt32(Idcategoria);
                    objEntidad.Nombre = txtnombre.Text.ToUpper();
                    objEntidad.Descripcion = txtdesc.Text.ToUpper();

                    objNegocio.EditandoCategoria(objEntidad);
                    MessageBox.Show("Registro se ha editado satsfactoriamente");
                    mostrarBuscarTabla("");
                    editarse = false;
                    Limpiar();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("El registro no se ha editado correctamente" + ex);
                }

                
            }

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objEntidad.Idcategoria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoCategoria(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");


            }
            else { MessageBox.Show("Seleccione la fila que desea eliminar"); }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
