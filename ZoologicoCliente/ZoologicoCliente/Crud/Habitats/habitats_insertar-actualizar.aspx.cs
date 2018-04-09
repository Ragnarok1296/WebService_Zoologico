using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Habitats_habitats_insertar_actualizar : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        try {

            if (!IsPostBack) {

                datosHabitad obj = (datosHabitad)Session["DataHabitats"];

                if (obj != null) {

                    txtbId.Text = obj.Id;
                    txtbDescripcion.Text = obj.Descripcion;
                    txtbClima.Text = obj.Clima;
                    txtbDimension.Text = obj.Dimension.ToString();

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
            myObject.descripcion = txtbDescripcion.Text;
            myObject.clima = txtbClima.Text;
            myObject.dimension = Convert.ToDecimal(txtbDimension.Text);
            string json = JsonConvert.SerializeObject(myObject);

            WSHabitat.WS_HabitadClient client = new WSHabitat.WS_HabitadClient();
            String respuesta = "1";

            if (btnInsertar.Text == "Actualizar")
                respuesta = client.actualizarHabitad("[" + json + "]");
            else if (btnInsertar.Text == "Insertar")
                respuesta = client.insertarHabitad("[" + json + "]");

            if(respuesta.Equals("1"))
                Response.Redirect("habitats.aspx");
            else
                Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");


        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");
            
        }

    }

}