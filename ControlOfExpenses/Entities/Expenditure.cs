using ControlOfExpenses.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlOfExpenses.Entities
{
    public class Expenditure
    {
        //public string Classification { get; set; }
        public string ClassificationExpenditure { get; set; } 
        public DateTime Expenditure_Date { get; set; }
        public decimal Unitaty_Value { get; set; }
        public int Amount { get; set; }
        public decimal ValorTotal { get; set; }
        public string Form_Payment { get; set; }
        public string PersonName { get; set; }
        public string Comment { get; set; }
        public string Replay { get; set; }

        public StatusAproval statusAproval { get; set; }

        public Expenditure()
        {
        }
        public Expenditure(String classificationExpenditure, DateTime expenditure_Date, decimal unitaty_Value, int amount, string form_Payment, string personName, string comment, string replay, StatusAproval statusAproval)
        {
            ClassificationExpenditure = classificationExpenditure;
            Expenditure_Date = expenditure_Date;
            Unitaty_Value = unitaty_Value;
            Amount = amount;
            Form_Payment = form_Payment;
            PersonName = personName;
            Comment = comment;
            Replay = replay;
            this.statusAproval = StatusAproval.Aguardando_Aprovação;
        }

        public decimal ValueTotal(decimal unitaty_Value, int amount)
        {
            return unitaty_Value * amount;
        }

      
    }
}