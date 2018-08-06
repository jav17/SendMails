using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnviarCorreos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            MailMessage mensaje = new MailMessage();

            mensaje.To.Add(new MailAddress(txtDestino.Text));
            mensaje.From = new MailAddress(txtOrigen.Text + label4.Text);
            mensaje.Subject = "MENSAJE DE PRUEBA CON VS2017 :D";
            mensaje.Body = txtMensaje.Text;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;

            //NetworkCredential credentials = new NetworkCredential(txtOrigen.Text, txtPassword.Text, "");
            NetworkCredential credentials = new NetworkCredential("junioravila1@gmail.com", "te16love11you", "");
            client.Credentials = credentials;
            
            try
            {
                client.Send(mensaje);
                MessageBox.Show("MENSAJE ENVIADO");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al enviar\n ERROR: " + ex.Message);
            }
        }
    }
}
