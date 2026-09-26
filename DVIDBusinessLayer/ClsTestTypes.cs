using DVIDDataAcessLayer;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDBusinessLayer
{
    public class ClsTestTypes
    {
        private enum EnMode { Add=0, Update=1}


        public int ID {  get;private set; }
        public string Title { get;  set; }
        public string Description { get; set; }
        public float Fees {  get; set; }
        private EnMode _Mode;

        public ClsTestTypes()
        {
            ID=-1;
            Title="";
            Description="";
            Fees=0;

            _Mode = EnMode.Add;
        }
        public ClsTestTypes(int id,string title,string description,float fees)
        {
            this.ID=id;
            this.Title=title;
            this.Description=description;
            this.Fees = fees;

            _Mode=EnMode.Update;
        }

        //R
        public static ClsTestTypes Find(int id)
        {
            string title = "", description = "";
            float fees = 0;

            if(ClsTestTypesDataAccess.Find(id,ref title,ref description,ref fees))
            {
                return new ClsTestTypes(id,title,description,fees);
            }
            return null;
        }
        public static DataTable GetAll()
        {
            return ClsTestTypesDataAccess.GetAll();
        }

        //C
        private bool _Add()
        {
            this.ID=ClsTestTypesDataAccess.Add(this.Title,this.Description,this.Fees);
            return (this.ID!=-1);
        }
        //U
        private bool _Update()
        {
            return ClsTestTypesDataAccess.Update(this.ID,this.Title,this.Description,this.Fees);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case EnMode.Add:
                    if (_Add())
                    {
                        _Mode = EnMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case EnMode.Update:
                    return _Update();
                
                default: return false;
            }
        }
        
        public static bool IsExsit(int id)
        {
            return ClsTestTypesDataAccess.IsExsit(id);
        }
    }
}
