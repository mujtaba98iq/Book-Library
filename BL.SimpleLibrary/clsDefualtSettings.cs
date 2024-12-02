using System;
using System.Data;
using DB_Simple_LibraryDataAccessLayer;
namespace SettingsBusinessLayer
{

public class clsDefualtSettings
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;
public byte DefualtBorrowDays {get; set;}
public byte DefualtFineDay {get; set;}


public clsDefualtSettings()
{
this.DefualtBorrowDays = default;
this.DefualtFineDay = default;


Mode = enMode.AddNew;

}

private clsDefualtSettings( byte DefualtBorrowDays,  byte DefualtFineDay)
{
this.DefualtBorrowDays = DefualtBorrowDays;
this.DefualtFineDay = DefualtFineDay;


Mode = enMode.Update;

}


     static  public int GetDeffultBorrowDays()
        {
            //call DataAccess Layer 

            int DefualtBorrowDays = (byte)clsSettingsDataAccess.GetDeffultBorrowDays();

            return DefualtBorrowDays;

        }
        static  public int GetDeffultBorrowCost()
        {
            //call DataAccess Layer 

            int DefualtBorrowCost = (byte)clsSettingsDataAccess.GetDeffultBorrowCost();

            return DefualtBorrowCost;

        }

        private bool _AddNewDefualtBorrowDa()
{
//call DataAccess Layer 

this.DefualtBorrowDays = (byte)clsSettingsDataAccess.AddNewDefualtBorrowDa(this.DefualtFineDay);

return (this.DefualtBorrowDays != -1);

}

private bool _UpdateDefualtBorrowDa()
{
//call DataAccess Layer 

return clsSettingsDataAccess.UpdateDefualtBorrowDa(this.DefualtBorrowDays, this.DefualtFineDay);

}

public static clsDefualtSettings Find(byte DefualtBorrowDays)
{
byte DefualtFineDay = default;


if(clsSettingsDataAccess.GetDefualtBorrowDaInfoByID(DefualtBorrowDays, ref DefualtFineDay))
return new clsDefualtSettings( DefualtBorrowDays,  DefualtFineDay);
else
return null;

}

        public bool Save()
        {
            

            switch  (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDefualtBorrowDa())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDefualtBorrowDa();

            }




            return false;
        }

public static DataTable GetAllSettings(){return clsSettingsDataAccess.GetAllSettings();}

public static bool DeleteDefualtBorrowDa(byte DefualtBorrowDays){return  clsSettingsDataAccess.DeleteDefualtBorrowDa(DefualtBorrowDays);}

public static bool isDefualtBorrowDaExist(byte DefualtBorrowDays){return clsSettingsDataAccess.IsDefualtBorrowDaExist(DefualtBorrowDays);}


}

}