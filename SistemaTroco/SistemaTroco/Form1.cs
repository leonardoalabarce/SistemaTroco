using NHibernate;
using SistemaTroco.Classe;
using System;
using System.Windows.Forms;
using MapeamentoOR;
using SistemaTroco.Utils;

namespace SistemaTroco
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //  }



        private void txtValorRecebido_TextChanged(object sender, EventArgs e)
        {
            if ((txtValorTotal.Text != "") && (txtValorPago.Text != ""))
            {
                Resultado resultado = new Resultado();
                resultado = TrocoHelper.calculaTroco(Convert.ToDouble(txtValorTotal.Text), Convert.ToDouble(txtValorPago.Text));

                txtTroco.Text = resultado.Troco.ToString();
                lblResultado.Text = resultado.Descricao.ToString();

                //      calculaTroco(Convert.ToDouble(txtValorTotal.Text), Convert.ToDouble(txtValorPago.Text));
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtValorPago.Text) < Convert.ToDouble(txtValorTotal.Text))
            {
                MessageBox.Show("Pagamento insuficiente, faltam R$" + (Convert.ToDouble(txtValorTotal.Text) - Convert.ToDouble(txtValorPago.Text)), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                Troco troco = new Troco();
                troco.ValorTotal = Convert.ToDouble(txtValorTotal.Text);
                troco.ValorPago = Convert.ToDouble(txtValorPago.Text);
                troco.ValorRecebido = Convert.ToDouble(txtTroco.Text);
                troco.Notas = lblResultado.Text;

                ISession session = NHibernateHelper.GetSession();
                session.Save(troco);
                session.Flush();
                session.Close();

                MessageBox.Show("Dados gravados com sucesso.", "informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtValorTotal.Clear();
                txtValorPago.Clear();
                txtTroco.Clear();
                lblResultado.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SomenteNumero(e);
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SomenteNumero(e);
        }
    }
}
