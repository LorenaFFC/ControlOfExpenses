using ControlOfExpenses.ADO;
using ControlOfExpenses.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ControlOfExpenses
{
    public class MExpenditure
    {
        List<Expenditure> expenditures = new List<Expenditure>();
        List<ClassificationExpenditure> ClassificationExpenditures = new List<ClassificationExpenditure>();
        Expenditure expenditure;
        private ConnectionManager connectionManager;

        //public void InsertEXPENDITURE(string Classification, DateTime Expenditure_Date, double Unitary, int Amount, string FormPayment, string PersonName, string Comment,bool Replay, string Status)
        public void InsertEXPENDITURE(Expenditure expenditure)
        {
            string CommandText = "Insert into Financial.dbo.EXPENDITURE (CLASSIFICATION, EXPENDITURE_DATE, UNITARY_VALUE, AMOUNT, TOTAL_VALUE, FORM_PAYMENT, PERSON_NAME , COMMENT, REPLAY, STATUS) values (@CLASSIFICATION, @EXPENDITURE_DATE, @UNITARY_VALUE, @AMOUNT, @TOTAL_VALUE, @FORM_PAYMENT, @PERSON_NAME , @COMMENT, @REPLAY, @STATUS)";


            SqlParameter[] parameterList = {   new SqlParameter("@CLASSIFICATION",expenditure.ClassificationExpenditure),
                                               new SqlParameter("@EXPENDITURE_DATE",expenditure.Expenditure_Date),
                                               new SqlParameter("@UNITARY_VALUE",expenditure.Unitaty_Value),
                                               new SqlParameter("@AMOUNT",expenditure.Amount),
                                               new SqlParameter("@TOTAL_VALUE",expenditure.ValorTotal),
                                               new SqlParameter("@FORM_PAYMENT",expenditure.Form_Payment),
                                               new SqlParameter("@PERSON_NAME",expenditure.PersonName),
                                               new SqlParameter("@COMMENT",expenditure.Comment),
                                               new SqlParameter("@REPLAY",expenditure.Replay ),
                                               new SqlParameter("@STATUS",expenditure.statusAproval.ToString() )};

            ConnectionManager.ExecuteNonQuery(CommandText, parameterList);
            ConnectionManager.CloseConnection();
        }

        /*public void UpdateTable(Expenditure expenditure)
        {
            string CommandText = "UPDATE [dbo].[EXPENDITURE]" +
                                 " SET[CLASSIFICATION] = @CLASSIFICATION"
                                + ",[EXPENDITURE_DATE] = @EXPENDITURE_DATE"
                                + ",[UNITARY_VALUE] = @UNITARY_VALUE"
                                + ",[AMOUNT] = @AMOUNT"
                                + ",[TOTAL_VALUE] = @TOTAL_VALUE"
                                + ",[FORM_PAYMENT] = @FORM_PAYMENT"
                                + ",[PERSON_NAME] = @PERSON_NAME"
                                + ",[COMMENT] = @COMMENT"
                                + ",[REPLAY] = @REPLAY"
                                + ",[STATUS] = @STATUS"
                                + "WHERE [ID] =@ID";

            SqlParameter[] parameterList = {   new SqlParameter("@CLASSIFICATION",expenditure.ClassificationExpenditure),
                                               new SqlParameter("@EXPENDITURE_DATE",expenditure.Expenditure_Date),
                                               new SqlParameter("@UNITARY_VALUE",expenditure.Unitaty_Value),
                                               new SqlParameter("@AMOUNT",expenditure.Amount),
                                               new SqlParameter("@TOTAL_VALUE",expenditure.ValorTotal),
                                               new SqlParameter("@FORM_PAYMENT",expenditure.Form_Payment),
                                               new SqlParameter("@PERSON_NAME",expenditure.PersonName),
                                               new SqlParameter("@COMMENT",expenditure.Comment),
                                               new SqlParameter("@REPLAY",expenditure.Replay ),
                                               new SqlParameter("@STATUS",expenditure.statusAproval.ToString() )};

            ConnectionManager.ExecuteNonQuery(CommandText, parameterList);
            ConnectionManager.CloseConnection();
        }*/

        public DataTable ReportExpense()
        {
            ConnectionManager.GetSqlConnection();
            string commandQuery = "SELECT * FROM Financial.dbo.EXPENDITURE";
            DataTable dt= ConnectionManager.ExecuteQuery(commandQuery);
            return dt;
        }

    


    }
}