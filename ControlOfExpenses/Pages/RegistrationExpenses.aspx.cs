using ControlOfExpenses.Entities;
using ControlOfExpenses.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlOfExpenses.Pages
{
    public partial class RegistrationExpenses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Array listClassification = Enum.GetValues(typeof(ClassificationExpenditure));
                Array listFormPayment = Enum.GetValues(typeof(FormPayment));
                foreach (ClassificationExpenditure classification in listClassification)
                {
                    selectclassification.Items.Add(new ListItem(classification.ToString().Replace('_',' ')));
                }
                foreach (FormPayment formPayment in listFormPayment)
                {
                    selectformPayment.Items.Add(new ListItem(formPayment.ToString().Replace('_', ' ')));
                }
            }

        }

        protected void cadastro_Click(object sender, EventArgs e)
        {
            MExpenditure mExpenditure = new MExpenditure();
            string classification = selectclassification.Value.Replace('_', ' ');
            string formPayment = selectformPayment.Value.Replace('_', ' ');
            Expenditure cd = new Expenditure();
            cd.ClassificationExpenditure = classification;
            cd.Expenditure_Date = DateTime.Parse(txt_EXPENDITURE_DATE.Text);
            cd.Unitaty_Value = decimal.Parse(txt_UNITARY_VALUE.Text, CultureInfo.InvariantCulture);
            cd.Amount = int.Parse(txt_AMOUNT.Text);
            cd.ValorTotal = cd.ValueTotal(cd.Unitaty_Value, cd.Amount);
            cd.Form_Payment = formPayment;
            cd.PersonName = txt_PERSON_NAME.Text;
            cd.Comment = TextBox1.Text;
            cd.Replay = txt_REPLAY.Checked;
            cd.statusAproval = StatusAproval.Aguardando_Aprovação;

            mExpenditure.InsertEXPENDITURE(cd);

            //mExpenditure.InsertEXPENDITURE(classification, DateTime.Parse(txt_EXPENDITURE_DATE.Text), double.Parse(txt_UNITARY_VALUE.Text, CultureInfo.InvariantCulture), int.Parse(txt_AMOUNT.Text), formPayment, txt_PERSON_NAME.Text, TextBox1.Text, txt_REPLAY.Checked, "Aguardando Aprovação");
        }

      
    }
}