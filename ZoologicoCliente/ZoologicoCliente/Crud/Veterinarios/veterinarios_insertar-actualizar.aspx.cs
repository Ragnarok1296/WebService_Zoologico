using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Cuidadores_veterinarips_insertar_actualizar : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        try {

            if (!IsPostBack) {

                datosVeterinarios obj = (datosVeterinarios)Session["DataVeterinarios"];

                if (obj != null) {

                    txtbId.Text = obj.Id.ToString();
                    txtbNombre.Text = obj.Nombre;
                    txtbApellidos.Text = obj.Apellidos;
                    txtbEspecialidad.Text = obj.Especialidad;
                    txtbFechaIngreso.Text = obj.Fecha_ingreso;
                    txtbSalario.Text = obj.Salario.ToString();

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
            myObject.id = Convert.ToInt32(txtbId.Text);
            myObject.nombre = txtbNombre.Text;
            myObject.apellidos = txtbApellidos.Text;
            myObject.especialidad = txtbEspecialidad.Text;
            myObject.fecha_ingreso = txtbFechaIngreso.Text;
            myObject.salario = Convert.ToDecimal(txtbSalario.Text);
            string json = JsonConvert.SerializeObject(myObject);
            
            
            WSVeterinarios.WS_VeterinariosClient client = new WSVeterinarios.WS_VeterinariosClient();
            String respuesta = "1";
            
            if (btnInsertar.Text == "Actualizar")  
                respuesta = client.actualizarVeterinarios("[" + json + "]");  
            else if (btnInsertar.Text == "Insertar") 
                respuesta = client.insertarVeterinarios("[" + json + "]");

            if(respuesta.Equals("1"))
                Response.Redirect("veterinarios.aspx");
            else
                Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");
                

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");
            
        }

    }

}