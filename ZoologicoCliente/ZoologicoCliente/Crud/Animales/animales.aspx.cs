using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;


using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using iTextSharp.text.html.simpleparser;

public partial class Crud_Animales_animales : System.Web.UI.Page {

    WSAnimales.WS_AnimalesClient client;

    protected void Page_Load(object sender, EventArgs e) {

        try {

            client = new WSAnimales.WS_AnimalesClient();
            string fileJSON = client.consultaAnimales();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));
            GridView_Animales.DataSource = dt;

            if (!IsPostBack) {
                GridView_Animales.DataBind();
                cambiarContenido();
            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void GridView_Animales_RowCommand(object sender, GridViewCommandEventArgs e) {

        String respuesta;

        try {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView_Animales.Rows[index];

            if (e.CommandName == "Editar") {

                datosAnimales obj = new datosAnimales() {

                    Id = Convert.ToInt32(row.Cells[0].Text),
                    Nombre = row.Cells[1].Text,
                    Especie = row.Cells[2].Text,
                    Pais_origen = row.Cells[3].Text,
                    Estatus = row.Cells[4].Text,
                    Peso = Convert.ToDecimal(row.Cells[5].Text),
                    Altura = Convert.ToDecimal(row.Cells[6].Text),
                    Dieta = row.Cells[7].Text,
                    Sexo = row.Cells[8].Text,
                    Nivel_riesgo = row.Cells[9].Text,
                    Id_habitad = row.Cells[10].Text,
                    Pres_prop = row.Cells[11].Text

                };

                Session["DataAnimales"] = obj;
                Response.Redirect("animales_insertar-actualizar.aspx");

            } else if (e.CommandName == "Eliminar") {

                dynamic myObject = new ExpandoObject();
                myObject.id = Convert.ToInt32(row.Cells[0].Text);
                string json = JsonConvert.SerializeObject(myObject);

                respuesta = client.eliminarAnimales("[" + json + "]");

                if (respuesta.Equals("1"))
                    Response.Redirect("animales.aspx");
                else
                    Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

            } else if (e.CommandName == "Generar") {

                datosAnimales obj = new datosAnimales()
                {

                    Id = Convert.ToInt32(row.Cells[0].Text),
                    Nombre = row.Cells[1].Text,
                    Especie = row.Cells[2].Text,
                    Pais_origen = row.Cells[3].Text,
                    Estatus = row.Cells[4].Text,
                    Peso = Convert.ToDecimal(row.Cells[5].Text),
                    Altura = Convert.ToDecimal(row.Cells[6].Text),
                    Dieta = row.Cells[7].Text,
                    Sexo = row.Cells[8].Text,
                    Nivel_riesgo = row.Cells[9].Text,
                    Id_habitad = row.Cells[10].Text,
                    Pres_prop = row.Cells[11].Text

                };

                generarPDF(obj);

            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void btnInsertra_Click(object sender, EventArgs e) {

        datosAnimales obj = new datosAnimales();
        obj = null;
        Session["DataAnimales"] = obj;
        Response.Redirect("animales_insertar-actualizar.aspx");

    }

    private void cambiarContenido()
    {
        try
        {
            WSHabitat.WS_HabitadClient client2 = new WSHabitat.WS_HabitadClient();
            string fileJSON = client2.consultaHabitad();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));

            foreach (GridViewRow grid_row in GridView_Animales.Rows) {

                foreach (DataRow data_row in dt.Rows) {

                    if (grid_row.Cells[10].Text.Equals(Convert.ToString(data_row["id"])))
                        grid_row.Cells[10].Text = Convert.ToString(data_row["descripcion"]);

                }

                if (grid_row.Cells[11].Text.Equals("PER5"))
                    grid_row.Cells[11].Text = "Permanente";
                else
                    grid_row.Cells[11].Text = "Prestado";


            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    private void generarPDF(datosAnimales obj)
    {
        try
        {
            dynamic myObject = new ExpandoObject();
            myObject.idAnimal = Convert.ToInt32(obj.Id);
            string json = JsonConvert.SerializeObject(myObject);

            WSExpedientes.WS_ExpedientesClient clientRevisiones = new WSExpedientes.WS_ExpedientesClient();

            string fileJSON = clientRevisiones.consultarInformacionRevisiones("[" + json + "]");
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));

            GridView auxRevisiones = new GridView();

            auxRevisiones.DataSource = dt;
            auxRevisiones.DataBind();


            //Se crea pdf

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Expediente_" + obj.Nombre + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            hw.WriteLine("Expediente");
            hw.WriteBreak();
            hw.WriteBreak();

            hw.NewLine = obj.Id.ToString();
            hw.WriteLine("ID:  ");
            hw.WriteBreak();

            hw.NewLine = obj.Nombre;
            hw.WriteLine("Nombre:  ");
            hw.WriteBreak();

            hw.NewLine = obj.Especie;
            hw.WriteLine("Especie:  ");
            hw.WriteBreak();

            hw.NewLine = obj.Pais_origen;
            hw.WriteLine("Pais de Origen:  ");
            hw.WriteBreak();

            hw.NewLine = obj.Estatus;
            hw.WriteLine("Estatus:  ");
            hw.WriteBreak();

            hw.NewLine = obj.Peso.ToString();
            hw.WriteLine("Peso(kg):  ");
            hw.WriteBreak();

            hw.NewLine = obj.Altura.ToString();
            hw.WriteLine("Altura(mts):  ");
            hw.WriteBreak();

            hw.NewLine = obj.Dieta;
            hw.WriteLine("Dieta:  ");
            hw.WriteBreak();

            hw.NewLine = obj.Sexo;
            hw.WriteLine("Sexo:  ");
            hw.WriteBreak();

            hw.NewLine = obj.Nivel_riesgo;
            hw.WriteLine("Nivel de riesgo:  ");
            hw.WriteBreak();

            hw.NewLine = obj.Id_habitad;
            hw.WriteLine("Habitat:  ");
            hw.WriteBreak();

            hw.NewLine = obj.Pres_prop;
            hw.WriteLine("Prestado o propio:  ");
            hw.WriteBreak();

            hw.NewLine = auxRevisiones.Rows.Count.ToString();
            hw.WriteLine("Revisiones:  ");
            hw.WriteBreak();
            hw.WriteBreak();
            hw.WriteBreak();
            hw.WriteBreak();

            hw.NewLine = " ";
            auxRevisiones.RenderControl(hw);
            hw.NewLine = " ";
            hw.WriteBreak();



            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4_LANDSCAPE, 10f, 10f, 100f, 10f);
            HTMLWorker htmlParser = new HTMLWorker(pdfDoc);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            htmlParser.Parse(sr);
            pdfDoc.Close();

            Response.Write(pdfDoc);
            Response.End();

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void GridView_Animales_PageIndexChanging(object sender, GridViewPageEventArgs e) {

        GridView_Animales.PageIndex = e.NewPageIndex;
        GridView_Animales.DataBind();

    }


    protected void btnCuida_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Crud/Cuida/asignar.aspx");
    }

    protected void btnRevision_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Crud/Agendar/agendar.aspx");
    }
}