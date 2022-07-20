using INZFoodie.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace INZFoodie.ViewModel.Calculator.CalculatorMode
{
    public class CalculatorViewModelcs
    {    

        public string Bmi( string mass, string height)
        {
            var result = (double.Parse(mass) / (double.Parse(height) * double.Parse(height)))*10000;
            result = Math.Round(result, 2);
            return result.ToString();
        }

        public string idealBodyWeight(string height, string sex, string pattern)
        {
            double restult = 0;
            switch(pattern)
            {
                case "Broca":
                    if(sex =="Kobieta")
                    {
                        restult = (double.Parse(height) - 100);
                    }
                    else
                    {
                        restult = (double.Parse(height) - 100);
                    }
                    break;
                case "Lorentza":
                    if (sex == "Kobieta")
                    {
                        restult = (double.Parse(height) - 100 - (double.Parse(height) - 150) /2);
                    }
                    else
                    {
                        restult = (double.Parse(height) - 100 - (double.Parse(height) - 150) / 4);
                    }
                    break;
                case "Pattona":
                    if (sex == "Kobieta")
                    {
                        restult = (double.Parse(height) - 100 - (double.Parse(height) - 100) / 10);
                    }
                    else
                    {
                        restult = (double.Parse(height) - 100 - (double.Parse(height) - 100) / 20);
                    }
                    break;
            }
            return restult.ToString();
        }
        public string LeanBodyMass ( string height, string mass, string sex)
        {
            double result = 0;
           
            if (sex == "Kobieta")
            {
                result = (1.07 * double.Parse(mass) - (148 * ((double.Parse(mass)/ double.Parse(height))* ((double.Parse(mass) / double.Parse(height))))));
            }
            else
            {
                result = (1.1 * double.Parse(mass) - (128 * ((double.Parse(mass) / double.Parse(height)) * ((double.Parse(mass) / double.Parse(height))))));
            }
            result = Math.Round(result, 2);
            return result.ToString();
        }
        public double PalCal(string pal)
        {
            double PAL = 0;
            switch (pal)
            {
                case "Pacjent leżący w łóżku":
                    PAL = 1.2;
                    break;

                case "Niska aktywność fizyczna":
                    PAL = 1.4;
                    break;
                case "Umiarkowana aktywnosć fizyczna":
                    PAL = 1.6;
                    break;
                case "Aktywny tryb życia":
                    PAL = 1.8;
                    break;
                case "Bardzo aktywny tryb życia":
                    PAL = 2.0;
                    break;
                case "Wyczynowe uprawianie sportu":
                    PAL = 2.5;
                    break;

            }
            return PAL;
        }
        public string Miffin(string height, string mass, string age, string sex)
        {
            double result;
            result = ((10 * double.Parse(mass)) + (6.25 * double.Parse(height)) - (5 * double.Parse(age)));
            if (sex == "Kobieta")
            {
                result = result  - 161;
                return result.ToString();
            }
            else
            {
                result = result + 5;
                return result.ToString();
            }
        }
        public string Harris(string height, string mass, string age, string sex)
        {
            double result;            
            if (sex == "Kobieta")
            {
                result = (655.1 +(9.563* double.Parse(mass) + (1.85* double.Parse(height)) - (4.676 * double.Parse(age))));
                return result.ToString();
            }
            else
            {
                result = (66.5 + (13.75 * double.Parse(mass) + (5.003 * double.Parse(height)) - (6.775 * double.Parse(age))));
                return result.ToString();
            }
        }
        public string Cpm(string height, string mass, string age, string ppm, string sex, string pal)
        {
            double Pal = PalCal(pal);
            double result = 0;
            if(ppm == "Miffin")
            {
                var miffinPPM = double.Parse(Miffin(height, mass, age, sex));
                result = miffinPPM * Pal;
                return result.ToString();
            }
            else
            {
                var harrisPPM = double.Parse(Harris(height, mass, age, sex));
                result = harrisPPM * Pal;
                return result.ToString();
            }            
        }
        public string CpmTarg(string cpm, string target)
        {
            string cpmT = "";
            Double cpmm = 0;
            cpmm = Double.Parse(cpm);
            if(target == "Chce schudnąć")
            {
                cpmm = cpmm * 0.9;
            }
            else if(target == "Chce powiększyć masę mieśniową")
            {
                cpmm = cpmm * 1.1;
            }
            cpmT = cpmm.ToString();
            return cpmT;
        }
        
        public Personal PersonalCal(Personal personal)
        {

            string ppm = "Miffin";
            string pattern = "Broca";
            personal.CPM = Cpm(personal.Height, personal.Mass, personal.Age,ppm, personal.Gender, personal.Pal);
            personal.IdealBodyMass = idealBodyWeight(personal.Height,  personal.Gender, pattern);
            if(personal.Target != "Chce utrzymać wagę")
            {
                personal.CPMTarget = CpmTarg(personal.CPM, personal.Target);
            }
            else
            {
                personal.CPMTarget = personal.CPM;
            }

            personal.Protein = ((double.Parse(personal.CPMTarget)* personal.ProteinPer)/4).ToString();
            personal.Protein = Math.Round(double.Parse(personal.Protein), 2).ToString();

            personal.Fat = ((double.Parse(personal.CPMTarget) * personal.FatPer) / 9).ToString();
            personal.Fat = Math.Round(double.Parse(personal.Fat), 2).ToString();

            personal.Carbonates = ((double.Parse(personal.CPMTarget) * personal.CarbonatesPer) / 4).ToString();
            personal.Carbonates = Math.Round(double.Parse(personal.Carbonates), 2).ToString();

            return personal;
        }
        public string GlycemicLoad (string digestibleCarbohydrate, string glycemicIndex )
        {
            var result = (double.Parse(digestibleCarbohydrate) * double.Parse(glycemicIndex)) /100;
            return result.ToString();
        }
        public string waistToHipRatio (string sex, string waist, string hip)
        {
            double result = (double.Parse(waist) / double.Parse(hip));
            string res;
            result = Math.Round(result, 2);
            if (sex == "Kobieta")
            {
                if(result < 80)
                {
                    res = "Niski";
                }
                else if(result < 85 && result >81)
                {
                    res = "Umiarkowany";
                }
                else
                {
                    res = "Wysoki";
                }
            }
            else
            {
                if (result < 95)
                {
                    res = "Niski";
                }
                else if (result < 1 && result > 96)
                {
                    res = "Umiarkowany";
                }
                else
                {
                    res = "Wysoki";
                }
            }
            return result.ToString(); 
        }
        public string waistToHeightRatio(string sex, string waist, string height, string age)
        {
            var result = ((double.Parse(waist) / double.Parse(height)) *100);
            string res;
            if (result < 34)
            {
                res = "Ekstremalnie szczupły";
            }
            else if (double.Parse(age) < 15)
            {
                if(result > 35 && result < 45)
                {
                    res = "Szczupły";
                }
                else if(result > 46 && result < 51)
                {
                    res = "Zdrowy";
                }
                else if (result > 52 && result < 63)
                {
                    res = "Nadwaga";
                }
                else
                {
                    res = "Otyłość";
                }
            }
            else if (sex == "Kobieta")
            {
                if (result > 35 && result < 41)
                {
                    res = "Szczupły";
                }
                else if (result > 42 && result < 48)
                {
                    res = "Zdrowy";
                }
                else if (result > 49 && result < 53)
                {
                    res = "Nadwaga";
                }
                else if (result > 54 && result < 57)
                {
                    res = "Wielka Nadwaga";
                }
                else
                {
                    res = "Otyłość";
                }
            }
            else
            {
                if (result > 35 && result < 42)
                {
                    res = "Szczupły";
                }
                else if (result > 43 && result < 52)
                {
                    res = "Zdrowy";
                }
                else if (result > 53 && result < 57)
                {
                    res = "Nadwaga";
                }
                else if (result > 58 && result < 62)
                {
                    res = "Wielka Nadwaga";
                }
                else
                {
                    res = "Otyłość";
                }
            }
            return res;
        }


    }
}
