using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalDS2
{
    public partial class Inventario : Form
    {

        DS2Entities DS2Final = new DS2Entities();
        List<string> Model1 = new List<string>();

        public Inventario()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            this.proyectoFinalGrupoX_InventarioTableAdapter.Fill(this.tablaInventario.ProyectoFinalGrupoX_Inventario);
            lblHora.Text = DateTime.Now.ToShortTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var item = new InventarioModel
            {
                Producto = txtProducto.Text,
                Marca = txtMarca.Text,
                Stock = Convert.ToInt32(txtStock.Text),
                Descripcion = txtDescripcion.Text,
                Precio = Convert.ToDouble(txtPrecio.Text),
                Id = Guid.NewGuid()
            };
            this.proyectoFinalGrupoX_InventarioTableAdapter.Insert(item.Id,item.Seq,item.Producto,item.Descripcion,item.Marca,item.Precio,item.Stock);
            limpiarCampos();
            this.proyectoFinalGrupoX_InventarioTableAdapter.Fill(this.tablaInventario.ProyectoFinalGrupoX_Inventario);
        }

        private void limpiarCampos()
        {
            txtDescripcion.Text = "";
            txtMarca.Text = "";
            txtPrecio.Text = "";
            txtProducto.Text = "";
            txtStock.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string selection = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
            Guid id = Guid.Empty;
            id = new Guid(selection);

            var item = new InventarioModel
            {
                Producto = txtProducto.Text,
                Marca = txtMarca.Text,
                Stock = Convert.ToInt32(txtStock.Text),
                Descripcion = txtDescripcion.Text,
                Precio = Convert.ToDouble(txtPrecio.Text),
                Id = id
            };
            TablaInventario.ProyectoFinalGrupoX_InventarioDataTable dt = new TablaInventario.ProyectoFinalGrupoX_InventarioDataTable();
            dt.Clear();
            DataRow _item = dt.NewRow();
            _item["Id"] = item.Id;
            _item["Producto"] = item.Producto;
            _item["Marca"] = item.Marca;
            _item["Stock"] = item.Stock;
            _item["Descripcion"] = item.Descripcion;
            _item["Precio"] = item.Precio;
            _item["Seq"] = item.Seq;
            dt.Rows.Add(_item);
            this.proyectoFinalGrupoX_InventarioTableAdapter.Update(dt);
            limpiarCampos();
            this.proyectoFinalGrupoX_InventarioTableAdapter.Fill(this.tablaInventario.ProyectoFinalGrupoX_Inventario);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string selection = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
            Guid id = Guid.Empty;
            id = new Guid(selection);

            var item = new InventarioModel
            {
                Producto = txtProducto.Text,
                Marca = txtMarca.Text,
                Stock = Convert.ToInt32(txtStock.Text),
                Descripcion = txtDescripcion.Text,
                Precio = Convert.ToDouble(txtPrecio.Text),
                Id = id
            };
            this.proyectoFinalGrupoX_InventarioTableAdapter.Delete(item.Id, item.Seq, item.Producto, item.Descripcion, item.Marca, item.Precio, item.Stock);
            limpiarCampos();
            this.proyectoFinalGrupoX_InventarioTableAdapter.Fill(this.tablaInventario.ProyectoFinalGrupoX_Inventario);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string eproducto = dataGridView1.SelectedRows[0].Cells["Producto"].Value.ToString();
            string edescripcion = dataGridView1.SelectedRows[0].Cells["Descripcion"].Value.ToString();
            string emarca = dataGridView1.SelectedRows[0].Cells["Marca"].Value.ToString();
            string eprecio = dataGridView1.SelectedRows[0].Cells["Precio"].Value.ToString();
            string estock = dataGridView1.SelectedRows[0].Cells["Stock"].Value.ToString();

            txtProducto.Text = eproducto;
            txtDescripcion.Text = edescripcion;
            txtMarca.Text = emarca;
            txtPrecio.Text = eprecio;
            txtStock.Text = estock;
        }
    }
}
