﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Agendar_agendar : System.Web.UI.Page {

    WSRevisiones.WS_RevisionesClient client;

    protected void Page_Load(object sender, EventArgs e) {

        try {

            client = new WSRevisiones.WS_RevisionesClient();
            string fileJSON = client.consultaRevisiones();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));
            GridView_Revisiones.DataSource = dt;
            if (!IsPostBack) {
                GridView_Revisiones.DataBind();
                cambiarContenidoAnimal();
                cambiarContenidoVeterinario();
            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void GridView_Revisiones_RowCommand(object sender, GridViewCommandEventArgs e) {
        
        /*String respuesta;

        try {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView_Revisiones.Rows[index];

            if (e.CommandName == "Editar") {
            
                datosRevisiones obj = new datosRevisiones() {

                    Id = Convert.ToInt32(row.Cells[0].Text),
                    Descripcion = row.Cells[1].Text,
                    Fecha_ingreso = row.Cells[2].Text,
                    Fecha_salida = row.Cells[3].Text,
                    Tratamiento = row.Cells[4].Text,
                    Observaciones = row.Cells[5].Text,
                    Estatus = row.Cells[6].Text,
                    Id_animal = Convert.ToInt32(row.Cells[7].Text),
                    Id_veterinario = Convert.ToInt32(row.Cells[8].Text),
                    Concentrado = Convert.ToInt32(row.Cells[9].Text)

                };

                Session["DataRevisiones"] = obj;
                Response.Redirect("agendar_insertar-actualizar.aspx");

            } else if (e.CommandName == "Eliminar") {

                dynamic myObject = new ExpandoObject();
                myObject.id = Convert.ToInt32(row.Cells[0].Text);
                string json = JsonConvert.SerializeObject(myObject);
                
                respuesta = client.eliminarRevisiones("[" + json + "]");

                if(respuesta.Equals("1"))
                    Response.Redirect("agendar.aspx");
                else
                    Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }*/

    }

    protected void GridView_Revisiones_PageIndexChanging(object sender, GridViewPageEventArgs e) {

        GridView_Revisiones.PageIndex = e.NewPageIndex;
        GridView_Revisiones.DataBind();

    }

    protected void btnInsertar_Click(object sender, EventArgs e) {

        datosRevisiones obj = new datosRevisiones();
        obj = null;
        Session["DataRevisiones"] = obj;
        Response.Redirect("agendar_insertar-actualizar.aspx");

    }

    private void cambiarContenidoAnimal() {
        try {

            WSAnimales.WS_AnimalesClient clientAnimal = new WSAnimales.WS_AnimalesClient();
            string fileJSON = clientAnimal.consultaAnimales();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));

            foreach (GridViewRow grid_row in GridView_Revisiones.Rows) {

                foreach (DataRow data_row in dt.Rows) {

                    if (grid_row.Cells[7].Text.Equals(Convert.ToString(data_row["id"])))
                        grid_row.Cells[7].Text = Convert.ToString(data_row["nombre"]);

                }

            }

        }
        catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    private void cambiarContenidoVeterinario()
    {
        try
        {

            WSVeterinarios.WS_VeterinariosClient clientVeterinario = new WSVeterinarios.WS_VeterinariosClient();
            string fileJSON = clientVeterinario.consultaVeterinarios();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));

            foreach (GridViewRow grid_row in GridView_Revisiones.Rows)
            {

                foreach (DataRow data_row in dt.Rows)
                {

                    if (grid_row.Cells[8].Text.Equals(Convert.ToString(data_row["id"])))
                        grid_row.Cells[8].Text = Convert.ToString(data_row["nombre"]);

                }

            }

        }
        catch (Exception ex)
        {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

}