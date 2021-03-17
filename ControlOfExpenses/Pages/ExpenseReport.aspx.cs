using ControlOfExpenses.ADO;
using ControlOfExpenses.Entities;
using ControlOfExpenses.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlOfExpenses.Pages
{
    public partial class ExpenseReport : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridView1_SelectedIndexChanged();

            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.GridView1_SelectedIndexChanged();
        }

        protected void GridView1_SelectedIndexChanged()
        {
            MExpenditure mExpenditure = new MExpenditure();
            GridView1.DataSource = mExpenditure.ReportExpense();
            GridView1.DataBind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DropDownList ddlformaPgto = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("txtformadePagamto");
            DropDownList ddlStatus = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("txtStatus");
            var Unitaty_Value = ((GridView1.Rows[e.RowIndex].FindControl("txtvalueUnitary") as TextBox).Text.Trim());

            var conection = ConnectionManager.GetSqlConnection();
            string query = "UPDATE [Financial].[dbo].[EXPENDITURE] SET [EXPENDITURE_DATE] = @EXPENDITURE_DATE ,[UNITARY_VALUE] = @UNITARY_VALUE,[AMOUNT] = @AMOUNT,[TOTAL_VALUE] =  @UNITARY_VALUE * @AMOUNT  ,[FORM_PAYMENT] = @FORM_PAYMENT, [STATUS] = @STATUS WHERE ID = @ID";
            SqlCommand sqlCmd = new SqlCommand(query, conection);
            //sqlCmd.Parameters.AddWithValue("@CLASSIFICATION", (GridView1.Rows[e.RowIndex].FindControl("txtClassification") as TextBox).Text.Trim());
            sqlCmd.Parameters.AddWithValue("@EXPENDITURE_DATE", (GridView1.Rows[e.RowIndex].FindControl("txtExpenditure_date") as TextBox).Text.Trim());
            sqlCmd.Parameters.AddWithValue("@UNITARY_VALUE", decimal.Parse(Unitaty_Value, CultureInfo.InvariantCulture));
            sqlCmd.Parameters.AddWithValue("@AMOUNT", Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("txtamount") as TextBox).Text.Trim()));
            sqlCmd.Parameters.AddWithValue("@FORM_PAYMENT", ddlformaPgto.Text);
            sqlCmd.Parameters.AddWithValue("@STATUS", ddlStatus.Text);
            sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
            //selectformPayment.Value.Replace('_', ' ');
            sqlCmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            GridView1_SelectedIndexChanged();

            Response.Write("<script> alert('" + Unitaty_Value + "'); </script>");

            //Convert.ToDouble((GridView1.Rows[e.RowIndex].FindControl("txtvalueUnitary") as TextBox).Text.Trim())
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1_SelectedIndexChanged();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1_SelectedIndexChanged();

        }
        protected void button_approved(object sender, EventArgs e)
        {

            ImageButton ibtn1 = sender as ImageButton;
            int rowIndex = Convert.ToInt32(ibtn1.Attributes["RowIndex"]);


            var conection = ConnectionManager.GetSqlConnection();
            string query = "UPDATE [Financial].[dbo].[EXPENDITURE] SET   [STATUS] = 'Aprovada' WHERE ID = @ID";
            SqlCommand sqlCmd = new SqlCommand(query, conection);
            sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(rowIndex));
            sqlCmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            GridView1_SelectedIndexChanged();
            //Response.Write("<script> alert('" + rowIndex + "'); </script>");
        }
        protected void button_deny(object sender, EventArgs e)
        {

            ImageButton ibtn1 = sender as ImageButton;
            int rowIndex = Convert.ToInt32(ibtn1.Attributes["RowIndex"]);


            var conection = ConnectionManager.GetSqlConnection();
            string query = "UPDATE [Financial].[dbo].[EXPENDITURE] SET   [STATUS] = 'Reprovada' WHERE ID = @ID";
            SqlCommand sqlCmd = new SqlCommand(query, conection);
            sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(rowIndex));
            sqlCmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            GridView1_SelectedIndexChanged();
            //Response.Write("<script> alert('" + rowIndex + "'); </script>");
        }
        protected void button_revision(object sender, EventArgs e)
        {

            ImageButton ibtn1 = sender as ImageButton;
            int rowIndex = Convert.ToInt32(ibtn1.Attributes["RowIndex"]);


            var conection = ConnectionManager.GetSqlConnection();
            string query = "UPDATE [Financial].[dbo].[EXPENDITURE] SET   [STATUS] = 'Revisão' WHERE ID = @ID";
            SqlCommand sqlCmd = new SqlCommand(query, conection);
            sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(rowIndex));
            sqlCmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            GridView1_SelectedIndexChanged();
            //Response.Write("<script> alert('" + rowIndex + "'); </script>");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            MExpenditure mExpenditure = new MExpenditure();


            GridView1.DataSource = mExpenditure.ReportExpenseFilter(int.Parse(month.Text), int.Parse(year.Text), REPLAY.SelectedValue.ToString(), STATUS.SelectedValue.ToString());
            GridView1.DataBind();
          //  Response.Write("<script> alert('" + REPLAY.SelectedValue.ToString() + "'); </script>");

        }
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            MExpenditure mExpenditure = new MExpenditure();
            GridView1.DataSource = mExpenditure.ReportExpense();
            GridView1.DataBind();
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationExpenses.aspx");
        }
    }
}