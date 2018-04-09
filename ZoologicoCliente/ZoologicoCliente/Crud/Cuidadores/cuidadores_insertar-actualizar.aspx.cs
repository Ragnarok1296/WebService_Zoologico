using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Cuidadores_cuidadores_insertar_actualizar : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        try {

            if (!IsPostBack) {

                datosCuidadores obj = (datosCuidadores)Session["DataCuidadores"];

                if (obj != null) {

                    txtbId.Text = obj.Id.ToString();
                    txtbNombre.Text = obj.Nombre;
                    txtbApellidos.Text = obj.Apellidos;
                    txtbNacionalidad.Text = obj.Nacionalidad;
                    txtbTelefono.Text = obj.Telefono;
                    txtbEstatus.Text = obj.Estatus;
                    txtbFIngreso.Text = obj.Fecha_ingreso;

                    txtbId.ReadOnly = true;
                    btnInsertar.Text = "Actualizar";

                } else
                    btnInsertar.Text = "Insertar";

            }
        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void btnInsertar_Click(object sender, EventArgs e) {

        try {

            dynamic myObject = new ExpandoObject();
            myObject.id = txtbId.Text;
            myObject.nombre = txtbNombre.Text;
            myObject.apellidos = txtbApellidos.Text;
            myObject.nacionalidad = txtbNacionalidad.Text;
            myObject.telefono = txtbFIngreso.Text;
            myObject.estatus = txtbEstatus.Text;
            myObject.fecha_ingreso = txtbFIngreso.Text;
            string json = JsonConvert.SerializeObject(myObject);

            WSCuidadores.WS_CuidadoresClient client = new WSCuidadores.WS_CuidadoresClient();
            String respuesta = "1";

            if (btnInsertar.Text == "Actualizar")
                respuesta = client.actualizarCuidadores("[" + json + "]");
            else if (btnInsertar.Text == "Insertar")
                respuesta = client.insertarCuidadores("[" + json + "]");

            if(respuesta.Equals("1"))
                Response.Redirect("cuidadores.aspx");
            else
                Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

}