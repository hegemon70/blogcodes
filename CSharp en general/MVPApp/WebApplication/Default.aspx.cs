using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador;
namespace WebApplication
{
    public partial class _Default : System.Web.UI.Page, IVistaOperaciones
    {
        private PresentadorOperaciones _presentador;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _presentador = new PresentadorOperaciones(this);
            Load += Page_Load;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                _presentador.IniciarVista();
            }
        }
        protected void btSumClick(object sender, EventArgs e)
        {
            _presentador.ActualizarVista();
        }

        #region Implementation of IVistaOperaciones

        public double Num1
        {
            get { return !string.IsNullOrEmpty(txtNum1.Text) ? Convert.ToDouble(txtNum1.Text) : 0; }
            set { txtNum1.Text = value.ToString(); }
        }

        public double Num2
        {
            get { return !string.IsNullOrEmpty(txtNum2.Text) ? Convert.ToDouble(txtNum2.Text) : 0; }
            set { txtNum2.Text = value.ToString(); }
        }

        public double Resultado
        {
            set { lbResultado.Text = value.ToString(); }
        }

        #endregion
    }
}
