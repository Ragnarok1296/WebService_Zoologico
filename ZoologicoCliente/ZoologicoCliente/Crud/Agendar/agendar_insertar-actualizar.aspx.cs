using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Agendar_agendar_insertar_actualizar : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        try {

            if (!IsPostBack) {

                datosRevisiones obj = (datosRevisiones)Session["DataRevisiones"];

                llenarListVeterinarios();
                llenarListAnimales();

                if (obj != null) {

                    txtbId.Text = obj.Id.ToString();
                    txtbDescripcion.Text = obj.Descripcion;
                    txtbFechaIngreso.Text = obj.Fecha_ingreso;
                    txtbFechaSalida.Text = obj.Fecha_salida;
                    txtbTratamiento.Text = obj.Tratamiento;
                    txtbObservaciones.Text = obj.Observaciones;
                    txtbEstatus.Text = obj.Estatus;
                    ddlAnimal.SelectedValue = obj.Id_animal.ToString();
                    ddlIDVeterinario.SelectedValue = obj.Id_veterinario.ToString();
                    txtbConcentrado.Text = obj.Concentrado.ToString();

                    txtbId.ReadOnly = true;
                    btnInsertar.Text = "Actualizar";

                    ddlIDAnimal.SelectedIndex = ddlAnimal.SelectedIndex;
                    ddlIDVeterinario.SelectedIndex = ddlVeterinario.SelectedIndex;

                } else
                    btnInsertar.Text = "Insertar";

            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void btnInsertar_Click(object sender, EventArgs e) {

        try {

            ddlIDAnimal.SelectedIndex = ddlAnimal.SelectedIndex;
            ddlIDVeterinario.SelectedIndex = ddlVeterinario.SelectedIndex;

            DateTime fechaIngreso = Convert.ToDateTime(txtbFechaIngreso.Text);
            DateTime fechaSalida = Convert.ToDateTime(txtbFechaSalida.Text);

            if (fechaIngreso < fechaSalida)
            {

                dynamic myObject = new ExpandoObject();
                myObject.id = Convert.ToInt32(txtbId.Text);
                myObject.descripcion = txtbDescripcion.Text;
                myObject.fecha_ingreso = txtbFechaIngreso.Text;
                myObject.fecha_salida = txtbFechaSalida.Text;
                myObject.tratamiento = txtbTratamiento.Text;
                myObject.observaciones = txtbObservaciones.Text;
                myObject.estatus = txtbEstatus.Text;
                myObject.id_animal = Convert.ToInt32(ddlIDAnimal.SelectedItem.Text);
                myObject.id_veterinario = Convert.ToInt32(ddlIDVeterinario.SelectedItem.Text);
                myObject.concentrado = Convert.ToInt32(txtbConcentrado.Text);
                string json = JsonConvert.SerializeObject(myObject);

                WSRevisiones.WS_RevisionesClient client = new WSRevisiones.WS_RevisionesClient();
                String respuesta = "1";
                /*if (btnInsertar.Text == "Actualizar")
                    respuesta = client.actualizarRevisones("[" + json + "]");
                else*/
                if (btnInsertar.Text == "Insertar")
                    respuesta = client.insertarRevisiones("[" + json + "]");

                if (respuesta.Equals("1"))
                    Response.Redirect("agendar.aspx");
                else
                    Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

            } else
                Response.Write("<script language=javascript> alert(' La fecha de ingreso no debe ser mayo a la de salida '); </script>");

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    private void llenarListAnimales()
    {

        try
        {
            WSAnimales.WS_AnimalesClient clientAnimales = new WSAnimales.WS_AnimalesClient();
            string fileJSON = clientAnimales.consultaAnimales();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));

            foreach (DataRow row in dt.Rows)
            {

                string descripcion = Convert.ToString(row["nombre"]);
                ddlAnimal.Items.Add(descripcion);
                string id = Convert.ToString(row["id"]);
                ddlIDAnimal.Items.Add(id);

            }

        }
        catch (Exception ex)
        {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    private void llenarListVeterinarios()
    {

        try
        {
            WSVeterinarios.WS_VeterinariosClient clientVeterinarios = new WSVeterinarios.WS_VeterinariosClient();
            string fileJSON = clientVeterinarios.consultaVeterinarios();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));

            foreach (DataRow row in dt.Rows)
            {

                string descripcion = Convert.ToString(row["nombre"]);
                ddlVeterinario.Items.Add(descripcion);
                string id = Convert.ToString(row["id"]);
                ddlIDVeterinario.Items.Add(id);

            }

        }
        catch (Exception ex)
        {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

}