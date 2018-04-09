using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Cuidadores_cuidadores : System.Web.UI.Page {

    WSCuidadores.WS_CuidadoresClient client;

    protected void Page_Load(object sender, EventArgs e) {

        try {

            client = new WSCuidadores.WS_CuidadoresClient();
            string fileJSON = client.consultaCuidadores();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));
            GridView_Cuidadores.DataSource = dt;

            if (!IsPostBack)
                GridView_Cuidadores.DataBind();

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void GridView_Cuidadores_RowCommand(object sender, GridViewCommandEventArgs e) {

        String respuesta;

        try {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView_Cuidadores.Rows[index];

            if (e.CommandName == "Editar") {

                datosCuidadores obj = new datosCuidadores() {

                    Id = row.Cells[0].Text,
                    Nombre = row.Cells[1].Text,
                    Apellidos = row.Cells[2].Text,
                    Nacionalidad = row.Cells[3].Text,
                    Telefono = row.Cells[4].Text,
                    Estatus = row.Cells[5].Text,
                    Fecha_ingreso = row.Cells[6].Text

                };

                Session["DataCuidadores"] = obj;
                Response.Redirect("cuidadores_insertar-actualizar.aspx");

            } else if (e.CommandName == "Eliminar") {

                dynamic myObject = new ExpandoObject();
                myObject.id = Convert.ToInt32(row.Cells[0].Text);
                string json = JsonConvert.SerializeObject(myObject);

                respuesta = client.eliminarCuidadores("[" + json + "]");

                if(respuesta.Equals("1"))
                    Response.Redirect("cuidadores.aspx");
                else
                    Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void btnInsertar_Click(object sender, EventArgs e) {

        datosCuidadores obj = new datosCuidadores();
        obj = null;
        Session["DataCuidadores"] = obj;
        Response.Redirect("cuidadores_insertar-actualizar.aspx");

    }

    protected void GridView_Cuidadores_PageIndexChanging(object sender, GridViewPageEventArgs e) {

        GridView_Cuidadores.PageIndex = e.NewPageIndex;
        GridView_Cuidadores.DataBind();

    }


    protected void btnCuida_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Crud/Cuida/asignar.aspx");
    }
}