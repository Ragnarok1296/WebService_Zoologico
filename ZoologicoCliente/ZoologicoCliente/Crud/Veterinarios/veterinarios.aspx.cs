using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Cuidadores_veterinarios : System.Web.UI.Page {

    WSVeterinarios.WS_VeterinariosClient client;

    protected void Page_Load(object sender, EventArgs e) {

        try {

            client = new WSVeterinarios.WS_VeterinariosClient();
            string fileJSON = client.consultaVeterinarios();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));
            GridView_Veterinarios.DataSource = dt;
            if (!IsPostBack)
                GridView_Veterinarios.DataBind();

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void GridView_Veterinarios_RowCommand(object sender, GridViewCommandEventArgs e) {

        String respuesta;

        try {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView_Veterinarios.Rows[index];

            if (e.CommandName == "Editar") {

                datosVeterinarios obj = new datosVeterinarios() {

                    Id = Convert.ToInt32(row.Cells[0].Text),
                    Nombre = row.Cells[1].Text,
                    Apellidos = row.Cells[2].Text,
                    Especialidad = row.Cells[3].Text,
                    Fecha_ingreso = row.Cells[4].Text,
                    Salario = Convert.ToDecimal(row.Cells[5].Text)

                };

                Session["DataVeterinarios"] = obj;
                Response.Redirect("veterinarios_insertar-actualizar.aspx");

            } else if (e.CommandName == "Eliminar") {

                dynamic myObject = new ExpandoObject();
                myObject.id = Convert.ToInt32(row.Cells[0].Text);
                string json = JsonConvert.SerializeObject(myObject);
                
                respuesta = client.eliminarVeterinarios("[" + json + "]");

                if(respuesta.Equals("1"))
                    Response.Redirect("veterinarios.aspx");
                else
                    Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void btnInsertar_Click(object sender, EventArgs e) {

        datosVeterinarios obj = new datosVeterinarios();
        obj = null;
        Session["DataVeterinarios"] = obj;
        Response.Redirect("veterinarios_insertar-actualizar.aspx");

    }

    protected void GridView_Veterinarios_PageIndexChanging(object sender, GridViewPageEventArgs e) {

        GridView_Veterinarios.PageIndex = e.NewPageIndex;
        GridView_Veterinarios.DataBind();

    }


    protected void btnRevision_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Crud/Agendar/agendar.aspx");
    }
}