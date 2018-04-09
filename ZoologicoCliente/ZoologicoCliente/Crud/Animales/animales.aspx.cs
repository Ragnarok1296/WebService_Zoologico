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

                //generarPDF();

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

            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    /*
    //Genera el pdf
    private void generarPDF()
    {
        
        Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        saveFileDialog1.InitialDirectory = @"C:";
        saveFileDialog1.Title = "Guardar Reporte";
        saveFileDialog1.DefaultExt = "pdf";
        saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf";
        saveFileDialog1.FilterIndex = 2;
        saveFileDialog1.RestoreDirectory = true;
        String numero = Ventas.NumeroComprobante("Boleta");
        saveFileDialog1.FileName = "Boleta_" + numero + "_" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
        string filename = "";
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            filename = saveFileDialog1.FileName;
        }

        if (filename.Trim() != "")
        {
            FileStream file = new FileStream(filename,
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite,
            FileShare.ReadWrite);
            PdfWriter.GetInstance(doc, file);
            doc.Open();
            string cliente = "Sr(a):  " + txtDatos.Text;
            string envio = "Fecha :" + DateTime.Now.ToString();

            Chunk chunk = new Chunk("Boleta", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));

            doc.Add(new Paragraph(chunk));
            doc.Add(new Paragraph("Nº " + numero.ToString()));
            doc.Add(new Paragraph("                       "));
            doc.Add(new Paragraph(envio));
            doc.Add(new Paragraph("                       "));
            doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
            doc.Add(new Paragraph("                       "));
            doc.Add(new Paragraph(cliente));
            doc.Add(new Paragraph("                       "));
            doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
            doc.Add(new Paragraph("                       "));
            doc.Add(new Paragraph("                       "));
            doc.Add(new Paragraph("                       "));
            GenerarDocumento(doc);
            doc.AddCreationDate();
            doc.Add(new Paragraph("______________________________________________", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD)));
            doc.Add(new Paragraph("Sello", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD)));
            doc.Close();
            Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
        }
    }

    //Genera el docuento para pdf
    public void GenerarDocumento(Document document)
    {
        int i, j;
        bool bandera;
        int columnas = dataGridView1.Columns.Count;
        PdfPTable datatable = new PdfPTable(columnas);
        datatable.DefaultCell.Padding = 3;
        float[] headerwidths = GetTamañoColumnas(dataGridView1);
        datatable.SetWidths(headerwidths);
        datatable.WidthPercentage = 100;
        datatable.DefaultCell.BorderWidth = 2;
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        for (i = 0; i < dataGridView1.ColumnCount; i++)
        {
            if (i == 0 || i == dataGridView1.Columns.Count - 1)
            {

                datatable.AddCell(" ");

            }
            else
            {
                datatable.AddCell(dataGridView1.Columns[i].HeaderText);
            }
        }
        datatable.HeaderRows = 1;
        datatable.DefaultCell.BorderWidth = 1;
        for (i = 0; i < dataGridView1.Rows.Count; i++)
        {
            bandera = true;
            for (j = 0; j < dataGridView1.Columns.Count; j++)
            {

                if (dataGridView1[j, i].Value != null)
                {

                    if (i == dataGridView1.Rows.Count - 2 && bandera == true)
                    {
                        for (int h = 0; h < 9; h++)
                        {

                            datatable.AddCell(" ");

                        }
                        bandera = false;
                    }


                    if (j == 0 || j == dataGridView1.Columns.Count - 1)
                    {

                        datatable.AddCell(" ");

                    }
                    else
                    {
                        datatable.AddCell(new Phrase(dataGridView1[j, i].Value.ToString()));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    }

                }
            }
            datatable.CompleteRow();
        }
        document.Add(datatable);
    }


    public float[] GetTamañoColumnas(DataGridView dg)
    {
        float[] values = new float[dg.ColumnCount];
        for (int i = 0; i < dg.ColumnCount; i++)
        {
            values[i] = (float)dg.Columns[i].Width;
        }
        return values;

    }

    */

    protected void GridView_Animales_PageIndexChanging(object sender, GridViewPageEventArgs e) {

        GridView_Animales.PageIndex = e.NewPageIndex;
        GridView_Animales.DataBind();

    }

}