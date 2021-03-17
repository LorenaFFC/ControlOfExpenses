using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlOfExpenses.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Atualizagrid();

            }

        }
        protected void Atualizagrid()
        {
            MExpenditure mExpenditure = new MExpenditure();
            GridView1.DataSource = mExpenditure.ReportExpenseRel();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MExpenditure mExpenditure = new MExpenditure();
            GridView1.DataSource = mExpenditure.RelatorioDespesasAgregado(DateTime.Parse(DT_INICIAL.Text), DateTime.Parse(DT_FINAL.Text), txt_NomePessoa.Text);
            GridView1.DataBind();
     
        }
    }
}