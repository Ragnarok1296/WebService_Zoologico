using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Reportes_reportes : System.Web.UI.Page
{
    WSReportes.WS_ReportesClient client;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string monthddl()
    {
        String month = "01";

        if (ddlMonth.SelectedValue.Equals("Enero"))
            month = "01";
        if (ddlMonth.SelectedValue.Equals("Febrero"))
            month = "02";
        if (ddlMonth.SelectedValue.Equals("Marzo"))
            month = "03";
        if (ddlMonth.SelectedValue.Equals("Abril"))
            month = "04";
        if (ddlMonth.SelectedValue.Equals("Mayo"))
            month = "05";
        if (ddlMonth.SelectedValue.Equals("Junio"))
            month = "06";
        if (ddlMonth.SelectedValue.Equals("Julio"))
            month = "07";
        if (ddlMonth.SelectedValue.Equals("Agosto"))
            month = "08";
        if (ddlMonth.SelectedValue.Equals("Septiembre"))
            month = "09";
        if (ddlMonth.SelectedValue.Equals("Octubre"))
            month = "10";
        if (ddlMonth.SelectedValue.Equals("Noviembre"))
            month = "11";
        if (ddlMonth.SelectedValue.Equals("Diciembre"))
            month = "12";

        return month;
    }

    protected void btnGenerar_Click(object sender, EventArgs e)
    {

        try
        {
            client = new WSReportes.WS_ReportesClient();

            string mes = monthddl();


            dynamic myObjectCuidadores = new ExpandoObject();
            myObjectCuidadores.fecha_ingreso = ddlYear.SelectedValue + "-" + mes;
            string jsonCuidadores = JsonConvert.SerializeObject(myObjectCuidadores);

            string fileJSONCuidadores = client.reporteCuidadores("[" + jsonCuidadores + "]");
            DataTable dtCuidadores = (DataTable)JsonConvert.DeserializeObject(fileJSONCuidadores, typeof(DataTable));
            
            GridView_Reportes_Cuidadores.DataSource = dtCuidadores;
            GridView_Reportes_Cuidadores.DataBind();
            if (GridView_Reportes_Cuidadores.Rows.Count > 0)
                lblTablaCuidadores.Visible = true;
            else
                lblTablaCuidadores.Visible = false;
            


            dynamic myObjectAnimales = new ExpandoObject();
            myObjectAnimales.fecha_ad = ddlYear.SelectedValue + "-" + mes;
            string jsonAnimales = JsonConvert.SerializeObject(myObjectAnimales);

            string fileJSONAnimales = client.reporteAnimalesPermanentes("[" + jsonAnimales + "]");
            DataTable dtAnimaless = (DataTable)JsonConvert.DeserializeObject(fileJSONAnimales, typeof(DataTable));

            GridView_Reportes_Animales.DataSource = dtAnimaless;
            GridView_Reportes_Animales.DataBind();
            if (GridView_Reportes_Animales.Rows.Count > 0)
                lblTablaAnimales.Visible = true;
            else
                lblTablaAnimales.Visible = false;


        }
        catch (Exception ex)
        {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void GridView_Reporte_Cuidadores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView_Reportes_Cuidadores.PageIndex = e.NewPageIndex;
        GridView_Reportes_Cuidadores.DataBind();

    }

    protected void GridView_Reportes_Animales_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView_Reportes_Cuidadores.PageIndex = e.NewPageIndex;
        GridView_Reportes_Cuidadores.DataBind();

    }

}