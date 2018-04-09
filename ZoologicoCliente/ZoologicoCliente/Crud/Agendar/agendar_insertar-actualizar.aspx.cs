﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crud_Agendar_agendar_insertar_actualizar : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        try {

            if (!IsPostBack) {

                datosRevisiones obj = (datosRevisiones)Session["DataRevisiones"];

                if (obj != null) {

                    txtbId.Text = obj.Id.ToString();
                    txtbDescripcion.Text = obj.Descripcion;
                    txtbFechaIngreso.Text = obj.Fecha_ingreso;
                    txtbFechaSalida.Text = obj.Fecha_salida;
                    txtbTratamiento.Text = obj.Tratamiento;
                    txtbObservaciones.Text = obj.Observaciones;
                    txtbEstatus.Text = obj.Estatus;
                    txtbIDAnimal.Text = obj.Id_animal.ToString();
                    txtbIDVeterinario.Text = obj.Id_veterinario.ToString();
                    txtbConcentrado.Text = obj.Concentrado.ToString();

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

            DateTime fechaIngreso = Convert.ToDateTime(txtbFechaIngreso.Text);
            DateTime fechaSalida = Convert.ToDateTime(txtbFechaSalida.Text);

            if (fechaIngreso < fechaSalida)
            {

                dynamic myObject = new ExpandoObject();
                myObject.id = Convert.ToInt32(txtbId.Text);
                myObject.descripcion = txtbDescripcion.Text;
                myObject.fecha_ingreso = txtbFechaIngreso.Text;
                myObject.fecha_salida = txtbFechaSalida.Text;
                myObject.tratamiento = txtbTratamiento.Text;
                myObject.observaciones = txtbObservaciones.Text;
                myObject.estatus = txtbEstatus.Text;
                myObject.id_animal = Convert.ToInt32(txtbIDAnimal.Text);
                myObject.id_veterinario = Convert.ToInt32(txtbIDVeterinario.Text);
                myObject.concentrado = Convert.ToInt32(txtbConcentrado.Text);
                string json = JsonConvert.SerializeObject(myObject);

                WSRevisiones.WS_RevisionesClient client = new WSRevisiones.WS_RevisionesClient();
                String respuesta = "1";
                /*if (btnInsertar.Text == "Actualizar")
                    respuesta = client.actualizarRevisones("[" + json + "]");
                else*/
                if (btnInsertar.Text == "Insertar")
                    respuesta = client.insertarRevisiones("[" + json + "]");

                if (respuesta.Equals("1"))
                    Response.Redirect("agendar.aspx");
                else
                    Response.Write("<script language=javascript> alert('" + respuesta + "'); </script>");

            } else
                Response.Write("<script language=javascript> alert(' La fecha de ingreso no debe ser mayo a la de salida '); </script>");

        } catch (Exception ex) {

            Response.Write("<script language=javascript> alert('" + ex.Message + "'); </script>");

        }

    } 

}