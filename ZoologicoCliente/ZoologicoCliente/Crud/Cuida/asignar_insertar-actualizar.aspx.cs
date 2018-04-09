using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Cuida_asignar_insertar_actualizar : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (!IsPostBack)
            {

                datosCuida obj = (datosCuida)Session["DataCuida"];

                llenarListCuidadores();
                llenarListAnimales();

                if (obj != null)
                {

                    txtbID.Text = obj.Id.ToString();
                    ddlCuidador.SelectedValue = obj.Id_cuidador.ToString();
                    ddlAnimal.SelectedValue = obj.Id_animal.ToString();
                    txtbTurno.Text = obj.Turno;
                    txtbFecha.Text = obj.Fecha;

                    txtbID.ReadOnly = true;
                    btnInsertar.Text = "Actualizar";

                    ddlIDAnimal.SelectedIndex = ddlAnimal.SelectedIndex;
                    ddlIDCuidador.SelectedIndex = ddlCuidador.SelectedIndex;

                }
                else
                    btnInsertar.Text = "Insertar";

            }

        }
        catch (Exception ex)
        {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {

        try
        {

            ddlIDAnimal.SelectedIndex = ddlAnimal.SelectedIndex;
            ddlIDCuidador.SelectedIndex = ddlCuidador.SelectedIndex;
            
            dynamic myObject = new ExpandoObject();
            myObject.id = Convert.ToInt32(txtbID.Text);
            myObject.id_cuidador = ddlIDCuidador.SelectedItem.Text;
            myObject.id_animal = Convert.ToInt32(ddlIDAnimal.SelectedItem.Text);
            myObject.turno = txtbTurno.Text;
            myObject.fecha = txtbFecha.Text;
            string json = JsonConvert.SerializeObject(myObject);

            WSCuida.WS_CuidaClient client = new WSCuida.WS_CuidaClient();
            String respuesta = "1";
            /*if (btnInsertar.Text == "Actualizar")
                respuesta = client.actualizarRevisones("[" + json + "]");
            else*/
            if (btnInsertar.Text == "Insertar")
                respuesta = client.insertarCuida("[" + json + "]");

            if (respuesta.Equals("1"))
                Response.Redirect("asignar.aspx");
            else
                Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

            
        }
        catch (Exception ex)
        {

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

    private void llenarListCuidadores()
    {

        try
        {
            WSCuidadores.WS_CuidadoresClient clientCuidadores = new WSCuidadores.WS_CuidadoresClient();
            string fileJSON = clientCuidadores.consultaCuidadores();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));

            foreach (DataRow row in dt.Rows)
            {

                string descripcion = Convert.ToString(row["nombre"]);
                ddlCuidador.Items.Add(descripcion);
                string id = Convert.ToString(row["id"]);
                ddlIDCuidador.Items.Add(id);

            }

        }
        catch (Exception ex)
        {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

}