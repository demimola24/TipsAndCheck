using System;
using System.Collections.Generic;

namespace TipsAndChequesLibrary
{
    public class TipsAndCheques
{
 public decimal CalculateSplitAmount(decimal amount, int numberOfPeople)
 {
    if(numberOfPeople<1){
        throw new ArgumentException("Number of people must not be less than 1");
    }
    return Math.Round(amount/numberOfPeople, 2);
 }

   public Dictionary<string, decimal> CalculateTipAmount(Dictionary<string, decimal> costs, float tipPercentage)
        {
            if (tipPercentage < 0) throw new ArgumentException("Tip percentage cannot be negative");
            
            var totalCost = 0m;
            foreach (var cost in costs.Values)
            {
                totalCost += cost;
            }
            
            var tipAmounts = new Dictionary<string, decimal>();
            foreach (var entry in costs)
            {
                var name = entry.Key;
                var cost = entry.Value;
                var individualTip = Math.Round(cost / totalCost * (decimal)tipPercentage / 100 * totalCost, 2);
                tipAmounts[name] = individualTip;
            }
            
            return tipAmounts;
        }

        public decimal CalculateIndividualTip(decimal totalAmount, int numberOfPatrons, float tipPercentage)
        {
            if (numberOfPatrons <= 0) throw new ArgumentException("Number of patrons must be greater than 0");
            if (tipPercentage < 0) throw new ArgumentException("Tip percentage cannot be negative");

            decimal totalTip = totalAmount * (decimal)tipPercentage / 100;
            decimal tipPerPerson = totalTip / numberOfPatrons;
            
            return Math.Round(tipPerPerson, 2);
        }
    }


}