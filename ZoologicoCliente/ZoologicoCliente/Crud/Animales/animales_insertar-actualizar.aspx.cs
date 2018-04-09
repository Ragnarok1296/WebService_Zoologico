using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Animales_animales_insertar_actualizart : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        try {

            if (!IsPostBack) {

                datosAnimales obj = (datosAnimales)Session["DataAnimales"];
                
                llenarList();

                if (obj != null) {

                    txtbId.Text = obj.Id.ToString();
                    txtbNombre.Text = obj.Nombre;
                    txtbEspecie.Text = obj.Especie;
                    txtbPaisOrigen.Text = obj.Pais_origen;
                    txtbEstatus.Text = obj.Estatus;
                    txtbPeso.Text = obj.Peso.ToString();
                    txtbAltura.Text = obj.Altura.ToString();
                    txtbDieta.Text = obj.Dieta;
                    txtbSexo.Text = obj.Sexo;
                    txtbNivelRiesgo.Text = obj.Nivel_riesgo;
                    ddlHabitat.SelectedValue = obj.Id_habitad;

                    if (obj.Pres_prop.Equals("Prestado"))
                        ddlPres.SelectedValue = "Prestado";
                    else if (obj.Pres_prop.Equals("Permanente"))
                        ddlPres.SelectedValue = "Permanente";

                    btnInsertar.Text = "Actualizar";
                    txtbId.ReadOnly = true;
                    ddlID.SelectedIndex = ddlHabitat.SelectedIndex;

                } else
                    btnInsertar.Text = "Insertar";

            }

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    protected void btnInsertar_Click(object sender, EventArgs e) {

        try {
            ddlID.SelectedIndex = ddlHabitat.SelectedIndex;

            String prestado = "PER5";
            if (ddlPres.SelectedValue.Equals("Permanente"))
                prestado = "PER5";
            else if (ddlPres.SelectedValue.Equals("Prestado"))
                prestado = "PER3";

            dynamic myObject = new ExpandoObject();
            myObject.id = Convert.ToInt32(txtbId.Text);
            myObject.nombre = txtbNombre.Text;
            myObject.especie = txtbEspecie.Text;
            myObject.pais_origen = txtbPaisOrigen.Text;
            myObject.estatus = txtbEstatus.Text;
            myObject.peso = Convert.ToDecimal(txtbPeso.Text);
            myObject.altura = Convert.ToDecimal(txtbAltura.Text);
            myObject.dieta = txtbDieta.Text;
            myObject.sexo = txtbSexo.Text;
            myObject.nivel_riesgo = txtbNivelRiesgo.Text;
            myObject.id_habitad = ddlID.SelectedItem.Text;
            myObject.pres_prop = prestado;
            myObject.imagen = "ejem";
            string json = JsonConvert.SerializeObject(myObject);
            
            WSAnimales.WS_AnimalesClient client = new WSAnimales.WS_AnimalesClient();
            String respuesta = "1";

            if (btnInsertar.Text == "Actualizar")
                respuesta = client.actualizarAnimales("[" + json + "]");
            else if (btnInsertar.Text == "Insertar")
                respuesta = client.insertarAnimales("[" + json + "]");

            if(respuesta.Equals("1"))
                Response.Redirect("animales.aspx");
            else
                Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

        } catch (Exception ex ) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    }

    private void llenarList() {
        
        try { 
            WSHabitat.WS_HabitadClient client2 = new WSHabitat.WS_HabitadClient();
            string fileJSON = client2.consultaHabitad();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));

            foreach (DataRow row in dt.Rows) {

                string descripcion = Convert.ToString(row["descripcion"]);
                ddlHabitat.Items.Add(descripcion);
                string id = Convert.ToString(row["id"]);
                ddlID.Items.Add(id);

            }

        }
        catch (Exception ex)
        {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");
            
        }

    }

}