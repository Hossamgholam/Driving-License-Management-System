using DVIDBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DVlD.Global_Class
{
    public static class ClsGlobalUser
    {
        public static ClsUser CurrentUser;

        public static bool RememberMe(string UserName,string Password)
        {
            try
            {
                
                string CurrentDirection = Directory.GetCurrentDirectory();


                string FillPathe = CurrentDirection+"\\Date.txt";


                if (UserName==""&&File.Exists(FillPathe))
                {
                    File.Delete(FillPathe);
                    return true;
                }

                string saveDate = UserName+"#//#"+Password;

                using (StreamWriter writer = new StreamWriter(FillPathe))
                {
                    writer.WriteLine(saveDate);
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }
        public static bool GetStoredCreditional(ref string UserName, ref string Password)
        {
            try
            {
                string FillPathe = Directory.GetCurrentDirectory()+"\\Date.txt";

                if (File.Exists(FillPathe))
                {
                    using(StreamReader reader=new StreamReader(FillPathe))
                    {
                        string line = "";
                        while ((line=reader.ReadLine())!=null)
                        {
                            string[]result=line.Split(new string[]{"#//#"},StringSplitOptions.None);

                            UserName=result[0];
                            Password=result[1];
                        }
                        return true;    
                    }
                }
                else
                {
                    //fill note exsit becuse he choice not remember send Unsername "" the
                    return false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }
    }
}
