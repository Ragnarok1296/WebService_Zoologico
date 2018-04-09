using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Habitats_habitats : System.Web.UI.Page {

    WSHabitat.WS_HabitadClient client;

    protected void Page_Load(object sender, EventArgs e) {

        try {

            client = new WSHabitat.WS_HabitadClient();
            string fileJSON = client.consultaHabitad();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));
            GridView_Habitats.DataSource = dt;
            if (!IsPostBack)
                GridView_Habitats.DataBind();

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void GridView_Habitads_RowCommand(object sender, GridViewCommandEventArgs e) {

        String respuesta;

        try {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView_Habitats.Rows[index];

            if (e.CommandName == "Editar") {

                datosHabitad obj = new datosHabitad() {

                    Id = row.Cells[0].Text,
                    Descripcion = row.Cells[1].Text,
                    Clima = row.Cells[2].Text,
                    Dimension = Convert.ToDecimal(row.Cells[3].Text)

                };

                Session["DataHabitats"] = obj;
                Response.Redirect("habitats_insertar-actualizar.aspx");

            } else if (e.CommandName == "Eliminar") {

                dynamic myObject = new ExpandoObject();
                myObject.id = Convert.ToInt32(row.Cells[0].Text);
                string json = JsonConvert.SerializeObject(myObject);

                respuesta = client.eliminarHabitad("[" + json + "]");

                if(respuesta.Equals("1"))
                    Response.Redirect("habitats.aspx");
                else
                    Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void btnInsertar_Click(object sender, EventArgs e) {

        datosHabitad obj = new datosHabitad();
        obj = null;
        Session["DataHabitats"] = obj;
        Response.Redirect("habitats_insertar-actualizar.aspx");

    }

    protected void GridView_Habitats_PageIndexChanging(object sender, GridViewPageEventArgs e) {

        GridView_Habitats.PageIndex = e.NewPageIndex;
        GridView_Habitats.DataBind();

    }

}