using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Forms
{
    public partial class FilipReports : Form
    {
        public Database D2;
        public FilipReports()
        {
            InitializeComponent();
            D2 = new Database();
        }
        private void EmpRepButt_Click(object sender, EventArgs e)
        {
            /*  The function below will be the executor of the reports.
                Once the run report button is pressed it will execute each
                of the queries below depending on what filters the user 
                enters. Below are all the queries that we have decided to
                test in this app for the demo. 
             */

            DateTime EmpFrom = EmpDateFrom.Value.Date; //Get the starting date from user
            DateTime EmpTo = EmpDateTo.Value.Date;     //Get the ending date from the user


            //Which Employee sold the most units
            if (EmpFilterBox.Text == "Most Sold (Units)")
            {
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");
                EmpRepTable.Columns.Add("Amount", "Total");

                D2.query(" select distinct E_FName, E_LName, E_Email, COUNT(P.TID) as Total" +
                         " from Employee as E, Process as P, RentalTrans as R" +
                         " where E.EID = P.EID and R.TID = P.TID" + 
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " group by E_FName, E_LName, E_Email" +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(), 
                                         D2.myReader["E_LName"].ToString(), 
                                         D2.myReader["E_Email"], 
                                         D2.myReader["Total"].ToString());
                }
                D2.myReader.Close();
            }

            else if (EmpFilterBox.Text == "All Employees")
            {
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");
                EmpRepTable.Columns.Add("Branch", "Branch");
                EmpRepTable.Columns.Add("Name", "BranchName");



                D2.query(" select *" +
                         " from Employee as E, Branch as B" +
                         " where E.BID = B.BID");

                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"],
                                         D2.myReader["BID"],
                                         D2.myReader["Name"]);
                }

                D2.myReader.Close();
            }

            else if (EmpFilterBox.Text == "Most Sold ($)")
            {
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");
                EmpRepTable.Columns.Add("Amount", "TotalPrice");

                D2.query(" select distinct E_FName,E_LName, E_Email, sum(Cost) as TotalPrice" +
                         " from Employee as E, Process as P, RentalTrans as R" + 
                         " where E.EID = P.EID and R.TID = P.TID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " group by E_FName, E_LName, E_Email" +
                         " order by TotalPrice DESC");

                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"],
                                         D2.myReader["TotalPrice"].ToString());
                }

                D2.myReader.Close();
            }

            else if (EmpFilterBox.Text == "Only Sold to GM")
            {
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                D2.query(" select distinct E_FName,E_LName, E_Email" + 
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" + 
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and C.MembType = '1'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " except" + 
                         " select distinct E_FName, E_LName, E_Email" + 
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and C.MembType != '1'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')");


                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);                                     
                }


                D2.myReader.Close();
            }
            else if (EmpFilterBox.Text == "Only Edm Cust")
            {
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                D2.query(" select distinct E_FName,E_LName, E_Email" + 
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and C.City = 'Edmonton'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " except" +
                         " select distinct E_FName, E_LName, E_Email" +
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and C.City != 'Edmonton'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')");

                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
            }
            else if (EmpFilterBox.Text == "Sold Only Sedans")
            {
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                D2.query(" select distinct E_FName,E_LName, E_Email" +
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and R.CT_ID = '001'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " except" +
                         " select distinct E_FName, E_LName, E_Email" +
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and R.CT_ID != '001'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')");

                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
            }
            else if (EmpFilterBox.Text == "Sold Only SUV's")
            {
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                D2.query(" select distinct E_FName,E_LName, E_Email" +
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and R.CT_ID = '002'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " except" +
                         " select distinct E_FName, E_LName, E_Email" +
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and R.CT_ID != '002'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')");

                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
            }
            else if (EmpFilterBox.Text == "Sold Only Minivan's")
            {
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                D2.query(" select distinct E_FName,E_LName, E_Email" +
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and R.CT_ID = '003'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " except" +
                         " select distinct E_FName, E_LName, E_Email" +
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and R.CT_ID != '003'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')");

                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
            }
            else if (EmpFilterBox.Text == "Sold Only Luxury's")
            {
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                D2.query(" select distinct E_FName,E_LName, E_Email" +
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and R.CT_ID = '004'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " except" +
                         " select distinct E_FName, E_LName, E_Email" +
                         " from Employee as E, Process as P, RentalTrans as R, Customer as C" +
                         " where E.EID = P.EID and R.TID = P.TID and C.CID = R.CID and R.CT_ID != '004'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')");

                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
            }
        }

        private void CustRepButt_Click(object sender, EventArgs e)
        {
            DateTime CustFrom = CustDateFrom.Value.Date;
            DateTime CustTo = CustDateTo.Value.Date;

            if (CustFilterBox.Text == "Most Transactions")
            {
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");
                CustRepTable.Columns.Add("Email", "Total");

                D2.query(" select distinct FName,LName, Email, COUNT(TID) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " group by FName, LName, Email" +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"],
                                         D2.myReader["Total"].ToString());
                }
                D2.myReader.Close();
            }

            else if (CustFilterBox.Text == "All Customers")
            {
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "GoldMember");
                CustRepTable.Columns.Add("Email", "Email");
                CustRepTable.Columns.Add("City", "City");
                CustRepTable.Columns.Add("Street1", "Street1");
                CustRepTable.Columns.Add("Street2", "Street2");
                CustRepTable.Columns.Add("PostalCode", "PostalCode");

                D2.query(" select *" +
                         " from Customer as C");

                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["MembType"].ToString(),
                                         D2.myReader["Email"],
                                         D2.myReader["City"].ToString(),
                                         D2.myReader["Street 1"].ToString(),
                                         D2.myReader["Street 2"].ToString(),
                                         D2.myReader["PostalCode"].ToString());

                }

                D2.myReader.Close();
            }

            else if (CustFilterBox.Text == "Most Amount ($)")
            {
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");
                CustRepTable.Columns.Add("Email", "Total");

                D2.query("select distinct FName, LName, Email, sum(Cost) as TotalPrice" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " group by FName, LName, Email" +
                         " order by TotalPrice DESC");

                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"],
                                         D2.myReader["TotalPrice"].ToString());
                }

                D2.myReader.Close();
            }

            else if (CustFilterBox.Text == "Upgraded Customers")
            {
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                D2.query(" select distinct FName,LName, Email" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 0" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " group by FName, LName, Email" +
                         " having count(C.CID) > 3");

                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
            }

            else if (CustFilterBox.Text == "Bought Only Sedans")
            {
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                D2.query(" select distinct FName,LName, Email, CPhone" +
                         " from Customer as C, RentalTrans as R, C_PhoneNo as CP" +
                         " where C.CID = R.CID and R.CID = CP.CID and R.CT_ID = '001'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " except" +
                         " select distinct FName, LName, Email, CPhone" +
                         " from Customer as C, RentalTrans as R, C_PhoneNo as CP" +
                         " where C.CID = R.CID and R.CID = CP.CID and R.CT_ID != '001'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')");

                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
            }


            else if (CustFilterBox.Text == "Bought Only SUV's")
            {
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                D2.query(" select distinct FName,LName, Email, CPhone" +
                         " from Customer as C, RentalTrans as R, C_PhoneNo as CP" +
                         " where C.CID = R.CID and R.CID = CP.CID and R.CT_ID = '002'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " except" +
                         " select distinct FName, LName, Email, CPhone" +
                         " from Customer as C, RentalTrans as R, C_PhoneNo as CP" +
                         " where C.CID = R.CID and R.CID = CP.CID and R.CT_ID != '002'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')");

                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
            }



            else if (CustFilterBox.Text == "Bought Only Minivan's")
            {
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                D2.query(" select distinct FName,LName, Email, CPhone" +
                         " from Customer as C, RentalTrans as R, C_PhoneNo as CP" +
                         " where C.CID = R.CID and R.CID = CP.CID and R.CT_ID = '003'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " except" +
                         " select distinct FName, LName, Email, CPhone" +
                         " from Customer as C, RentalTrans as R, C_PhoneNo as CP" +
                         " where C.CID = R.CID and R.CID = CP.CID and R.CT_ID != '003'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')");

                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
            }

            else if (CustFilterBox.Text == "Bought Only Luxury's")
            {
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                D2.query(" select distinct FName,LName, Email, CPhone" +
                         " from Customer as C, RentalTrans as R, C_PhoneNo as CP" +
                         " where C.CID = R.CID and R.CID = CP.CID and R.CT_ID = '004'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " except" +
                         " select distinct FName, LName, Email, CPhone" +
                         " from Customer as C, RentalTrans as R, C_PhoneNo as CP" +
                         " where C.CID = R.CID and R.CID = CP.CID and R.CT_ID != '004'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')");

                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
            }

        }

        private void BranchRepButt_Click(object sender, EventArgs e)
        {
            DateTime BranchFrom = BranchDateFrom.Value.Date;
            DateTime BranchTo = BranchDateTo.Value.Date;

            if (BranchFilterBox.Text == "All Branches")
            {
                BranchRepTable.Columns.Clear();
                BranchRepTable.Columns.Add("BID", "BID");
                BranchRepTable.Columns.Add("Name", "Name");
                BranchRepTable.Columns.Add("Email", "Email");
                BranchRepTable.Columns.Add("PhoneNum", "PhoneNum");
                BranchRepTable.Columns.Add("BranchCity", "BranchCity");
                BranchRepTable.Columns.Add("Prov/State", "Prov/State");
                BranchRepTable.Columns.Add("Street1", "Street1");
                BranchRepTable.Columns.Add("Street2", "Street2");
                BranchRepTable.Columns.Add("PostalCode", "PostalCode");

                D2.query(" select *" +
                         " from Branch as B");

                while (D2.myReader.Read())
                {
                    BranchRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                         D2.myReader["Name"].ToString(),
                                         D2.myReader["B_Email"],
                                         D2.myReader["B_PhoneNo"],
                                         D2.myReader["City"].ToString(),
                                         D2.myReader["Province"].ToString(),
                                         D2.myReader["Street 1"].ToString(),
                                         D2.myReader["Street 2"].ToString(),
                                         D2.myReader["PostalCode"].ToString());
                }
                D2.myReader.Close();
            }

            else if (BranchFilterBox.Text == "Most Transactions")
            {
                BranchRepTable.Columns.Clear();
                BranchRepTable.Columns.Add("BID", "BID");
                BranchRepTable.Columns.Add("Name", "Name");
                BranchRepTable.Columns.Add("Email", "Email");
                BranchRepTable.Columns.Add("PhoneNum", "PhoneNum");
                BranchRepTable.Columns.Add("BranchCity", "BranchCity");
                BranchRepTable.Columns.Add("Prov/State", "Prov/State");
                BranchRepTable.Columns.Add("Street1", "Street1");
                BranchRepTable.Columns.Add("Street2", "Street2");
                BranchRepTable.Columns.Add("PostalCode", "PostalCode");
                BranchRepTable.Columns.Add("Amount", "Total");

                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode, Count(TID) as Total" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, B.[Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode" +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    BranchRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                          D2.myReader["Name"].ToString(),
                                          D2.myReader["B_Email"],
                                          D2.myReader["B_PhoneNo"],
                                          D2.myReader["City"].ToString(),
                                          D2.myReader["Province"].ToString(),
                                          D2.myReader["Street 1"].ToString(),
                                          D2.myReader["Street 2"].ToString(),
                                          D2.myReader["PostalCode"].ToString(),
                                          D2.myReader["Total"].ToString());
                }

                D2.myReader.Close();
            }

            else if (BranchFilterBox.Text == "Most Amount ($)")
            {
                BranchRepTable.Columns.Clear();
                BranchRepTable.Columns.Add("BID", "BID");
                BranchRepTable.Columns.Add("Name", "Name");
                BranchRepTable.Columns.Add("Email", "Email");
                BranchRepTable.Columns.Add("PhoneNum", "PhoneNum");
                BranchRepTable.Columns.Add("BranchCity", "BranchCity");
                BranchRepTable.Columns.Add("Prov/State", "Prov/State");
                BranchRepTable.Columns.Add("Street1", "Street1");
                BranchRepTable.Columns.Add("Street2", "Street2");
                BranchRepTable.Columns.Add("PostalCode", "PostalCode");
                BranchRepTable.Columns.Add("Amount", "Total");

                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode, sum(Cost) as TotalPrice" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, B.[Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode" +
                         " order by TotalPrice DESC");

                while (D2.myReader.Read())
                {
                    BranchRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                          D2.myReader["Name"].ToString(),
                                          D2.myReader["B_Email"],
                                          D2.myReader["B_PhoneNo"],
                                          D2.myReader["City"].ToString(),
                                          D2.myReader["Province"].ToString(),
                                          D2.myReader["Street 1"].ToString(),
                                          D2.myReader["Street 2"].ToString(),
                                          D2.myReader["PostalCode"].ToString(),
                                          D2.myReader["TotalPrice"].ToString());
                }

                D2.myReader.Close();
            }

            else if (BranchFilterBox.Text == "Dealt With GM")
            {
                BranchRepTable.Columns.Clear();
                BranchRepTable.Columns.Add("BID", "BID");
                BranchRepTable.Columns.Add("Name", "Name");
                BranchRepTable.Columns.Add("Email", "Email");
                BranchRepTable.Columns.Add("PhoneNum", "PhoneNum");
                BranchRepTable.Columns.Add("BranchCity", "BranchCity");
                BranchRepTable.Columns.Add("Prov/State", "Prov/State");
                BranchRepTable.Columns.Add("Street1", "Street1");
                BranchRepTable.Columns.Add("Street2", "Street2");
                BranchRepTable.Columns.Add("PostalCode", "PostalCode");

                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " from Branch as B, RentalTrans as R, Customer as C" +
                         " where B.BID = R.PickUpBID and R.CID = C.CID and C.MembType = '1'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " except" +
                         " select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " from Branch as B, RentalTrans as R, Customer as C" +
                         " where B.BID = R.PickUpBID and R.CID = C.CID and C.MembType != '1'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')");

                while (D2.myReader.Read())
                {
                    BranchRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                          D2.myReader["Name"].ToString(),
                                          D2.myReader["B_Email"],
                                          D2.myReader["B_PhoneNo"],
                                          D2.myReader["City"].ToString(),
                                          D2.myReader["Province"].ToString(),
                                          D2.myReader["Street 1"].ToString(),
                                          D2.myReader["Street 2"].ToString(),
                                          D2.myReader["PostalCode"].ToString());
                }

                D2.myReader.Close();
            }

            else if (BranchFilterBox.Text == "Deal With Non GM")
            {
                BranchRepTable.Columns.Clear();
                BranchRepTable.Columns.Add("BID", "BID");
                BranchRepTable.Columns.Add("Name", "Name");
                BranchRepTable.Columns.Add("Email", "Email");
                BranchRepTable.Columns.Add("PhoneNum", "PhoneNum");
                BranchRepTable.Columns.Add("BranchCity", "BranchCity");
                BranchRepTable.Columns.Add("Prov/State", "Prov/State");
                BranchRepTable.Columns.Add("Street1", "Street1");
                BranchRepTable.Columns.Add("Street2", "Street2");
                BranchRepTable.Columns.Add("PostalCode", "PostalCode");

                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " from Branch as B, RentalTrans as R, Customer as C" +
                         " where B.BID = R.PickUpBID and R.CID = C.CID and C.MembType = '0'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " except" +
                         " select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " from Branch as B, RentalTrans as R, Customer as C" +
                         " where B.BID = R.PickUpBID and R.CID = C.CID and C.MembType != '0'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')");

                while (D2.myReader.Read())
                {
                    BranchRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                          D2.myReader["Name"].ToString(),
                                          D2.myReader["B_Email"],
                                          D2.myReader["B_PhoneNo"],
                                          D2.myReader["City"].ToString(),
                                          D2.myReader["Province"].ToString(),
                                          D2.myReader["Street 1"].ToString(),
                                          D2.myReader["Street 2"].ToString(),
                                          D2.myReader["PostalCode"].ToString());
                }

                D2.myReader.Close();
            }

            else if (BranchFilterBox.Text == "Most Sedans")
            {
                BranchRepTable.Columns.Clear();
                BranchRepTable.Columns.Add("BID", "BID");
                BranchRepTable.Columns.Add("Name", "Name");
                BranchRepTable.Columns.Add("Email", "Email");
                BranchRepTable.Columns.Add("PhoneNum", "PhoneNum");
                BranchRepTable.Columns.Add("BranchCity", "BranchCity");
                BranchRepTable.Columns.Add("Prov/State", "Prov/State");
                BranchRepTable.Columns.Add("Street1", "Street1");
                BranchRepTable.Columns.Add("Street2", "Street2");
                BranchRepTable.Columns.Add("PostalCode", "PostalCode");
                BranchRepTable.Columns.Add("Amount", "Total");


                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode, COUNT(CT_ID) as totSedan" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID and CT_ID = '001'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " order by totSedan DESC");

                while (D2.myReader.Read())
                {
                    BranchRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                          D2.myReader["Name"].ToString(),
                                          D2.myReader["B_Email"],
                                          D2.myReader["B_PhoneNo"],
                                          D2.myReader["City"].ToString(),
                                          D2.myReader["Province"].ToString(),
                                          D2.myReader["Street 1"].ToString(),
                                          D2.myReader["Street 2"].ToString(),
                                          D2.myReader["PostalCode"].ToString(),
                                          D2.myReader["totSedan"].ToString());
                }

                D2.myReader.Close();
            }

            else if (BranchFilterBox.Text == "Most SUV's")
            {
                BranchRepTable.Columns.Clear();
                BranchRepTable.Columns.Add("BID", "BID");
                BranchRepTable.Columns.Add("Name", "Name");
                BranchRepTable.Columns.Add("Email", "Email");
                BranchRepTable.Columns.Add("PhoneNum", "PhoneNum");
                BranchRepTable.Columns.Add("BranchCity", "BranchCity");
                BranchRepTable.Columns.Add("Prov/State", "Prov/State");
                BranchRepTable.Columns.Add("Street1", "Street1");
                BranchRepTable.Columns.Add("Street2", "Street2");
                BranchRepTable.Columns.Add("PostalCode", "PostalCode");
                BranchRepTable.Columns.Add("Amount", "Total");


                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode, COUNT(CT_ID) as totSuv" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID and CT_ID = '002'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " order by totSuv DESC");

                while (D2.myReader.Read())
                {
                    BranchRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                          D2.myReader["Name"].ToString(),
                                          D2.myReader["B_Email"],
                                          D2.myReader["B_PhoneNo"],
                                          D2.myReader["City"].ToString(),
                                          D2.myReader["Province"].ToString(),
                                          D2.myReader["Street 1"].ToString(),
                                          D2.myReader["Street 2"].ToString(),
                                          D2.myReader["PostalCode"].ToString(),
                                          D2.myReader["totSuv"].ToString());
                }

                D2.myReader.Close();
            }

            else if (BranchFilterBox.Text == "Most Minivan's")
            {
                BranchRepTable.Columns.Clear();
                BranchRepTable.Columns.Add("BID", "BID");
                BranchRepTable.Columns.Add("Name", "Name");
                BranchRepTable.Columns.Add("Email", "Email");
                BranchRepTable.Columns.Add("PhoneNum", "PhoneNum");
                BranchRepTable.Columns.Add("BranchCity", "BranchCity");
                BranchRepTable.Columns.Add("Prov/State", "Prov/State");
                BranchRepTable.Columns.Add("Street1", "Street1");
                BranchRepTable.Columns.Add("Street2", "Street2");
                BranchRepTable.Columns.Add("PostalCode", "PostalCode");
                BranchRepTable.Columns.Add("Amount", "Total");


                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode, COUNT(CT_ID) as totMini" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID and CT_ID = '003'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " order by totMini DESC");

                while (D2.myReader.Read())
                {
                    BranchRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                          D2.myReader["Name"].ToString(),
                                          D2.myReader["B_Email"],
                                          D2.myReader["B_PhoneNo"],
                                          D2.myReader["City"].ToString(),
                                          D2.myReader["Province"].ToString(),
                                          D2.myReader["Street 1"].ToString(),
                                          D2.myReader["Street 2"].ToString(),
                                          D2.myReader["PostalCode"].ToString(),
                                          D2.myReader["totMini"].ToString());
                }

                D2.myReader.Close();
            }

            else if (BranchFilterBox.Text == "Most Luxury's")
            {
                BranchRepTable.Columns.Clear();
                BranchRepTable.Columns.Add("BID", "BID");
                BranchRepTable.Columns.Add("Name", "Name");
                BranchRepTable.Columns.Add("Email", "Email");
                BranchRepTable.Columns.Add("PhoneNum", "PhoneNum");
                BranchRepTable.Columns.Add("BranchCity", "BranchCity");
                BranchRepTable.Columns.Add("Prov/State", "Prov/State");
                BranchRepTable.Columns.Add("Street1", "Street1");
                BranchRepTable.Columns.Add("Street2", "Street2");
                BranchRepTable.Columns.Add("PostalCode", "PostalCode");
                BranchRepTable.Columns.Add("Amount", "Total");


                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode, COUNT(CT_ID) as totLux" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID and CT_ID = '004'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " order by totLux DESC");

                while (D2.myReader.Read())
                {
                    BranchRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                          D2.myReader["Name"].ToString(),
                                          D2.myReader["B_Email"],
                                          D2.myReader["B_PhoneNo"],
                                          D2.myReader["City"].ToString(),
                                          D2.myReader["Province"].ToString(),
                                          D2.myReader["Street 1"].ToString(),
                                          D2.myReader["Street 2"].ToString(),
                                          D2.myReader["PostalCode"].ToString(),
                                          D2.myReader["totLux"].ToString());
                }

                D2.myReader.Close();
            }

        }

        private void CustomRepButt_Click(object sender, EventArgs e)
        {
            DateTime CustFrom = CustomDateFrom.Value.Date;
            DateTime CustTo = CustomDateTo.Value.Date;
            string BranchDecision = BranchPick.Text.Split()[0];
            decimal AmountWritten = Convert.ToDecimal(AmtTextBox.Text);


            if (CustomFilterBox.Text == "Branch Revenue")
            {
                

                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "BID");
                CustomRepTable.Columns.Add("Name", "Name");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "PhoneNum");
                CustomRepTable.Columns.Add("BranchCity", "BranchCity");
                CustomRepTable.Columns.Add("Prov/State", "Prov/State");
                CustomRepTable.Columns.Add("Street1", "Street1"); 
                CustomRepTable.Columns.Add("Street2", "Street2");
                CustomRepTable.Columns.Add("PostalCode", "PostalCode");
                CustomRepTable.Columns.Add("Amount", "Total");

               

                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode, sum(Cost) as TotalPrice" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +                
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by BID, B.[Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by TotalPrice DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["BID"].ToString(),
                                          D2.myReader["Name"].ToString(),
                                          D2.myReader["B_Email"], 
                                          D2.myReader["B_PhoneNo"],
                                          D2.myReader["City"].ToString(), 
                                          D2.myReader["Province"].ToString(), 
                                          D2.myReader["Street 1"].ToString(),
                                          D2.myReader["Street 2"].ToString(),
                                          D2.myReader["PostalCode"].ToString(),
                                          D2.myReader["TotalPrice"].ToString());
                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "GM Transactions")
            {
                
                
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");
                

                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 1 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());
                                           
                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "Transactions")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");


                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 0 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "GM Purchase (Sedan)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");


                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 1 " +
                         " and R.CT_ID = 001" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "GM Purchase (SUV)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");


                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 1 " +
                         " and R.CT_ID = 002" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "GM Purchase (Minivan)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");


                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 1 " +
                         " and R.CT_ID = 003" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "GM Purchase (Luxury)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");


                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 1 " +
                         " and R.CT_ID = 004" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "Purchase (Sedan)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");


                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 0 " +
                         " and R.CT_ID = 001" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }


            if (CustomFilterBox.Text == "Purchase (SUV)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");


                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 0 " +
                         " and R.CT_ID = 002" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }


            if (CustomFilterBox.Text == "Purchase (Minivan)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");


                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 0 " +
                         " and R.CT_ID = 003" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }


            if (CustomFilterBox.Text == "Purchase (Luxury)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");


                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 0 " +
                         " and R.CT_ID = 004" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close(); 
            }

            if (CustomFilterBox.Text == "GM Transactions (Edm)")
            {

    
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R, Branch as B" +
                         " where C.CID = R.CID and C.MembType = 1 " +
                         " and C.City = 'Edmonton'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }
            if (CustomFilterBox.Text == "GM Transactions (Edm)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R, Branch as B" +
                         " where C.CID = R.CID and B.BID = R.PickupBID and C.MembType = 1 " +
                         " and C.City = 'Edmonton'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "GM Transactions (Van)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R, Branch as B" +
                         " where C.CID = R.CID and B.BID = R.PickupBID and C.MembType = 1 " +
                         " and C.City = 'Vancouver'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "GM Transactions (Tor)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R, Branch as B" +
                         " where C.CID = R.CID and B.BID = R.PickupBID and C.MembType = 1 " +
                         " and C.City = 'Toronto'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "GM Transactions (Mia)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R, Branch as B" +
                         " where C.CID = R.CID and B.BID = R.PickupBID and C.MembType = 1 " +
                         " and C.City = 'Miami'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "Transactions (Edm)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R, Branch as B" +
                         " where C.CID = R.CID and B.BID = R.PickupBID and C.MembType = 0 " +
                         " and C.City = 'Edmonton'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "Transactions (Van)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R, Branch as B" +
                         " where C.CID = R.CID and B.BID = R.PickupBID and C.MembType = 1 " +
                         " and C.City = 'Vancouver'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "Transactions (Tor)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R, Branch as B" +
                         " where C.CID = R.CID and B.BID = R.PickupBID and C.MembType = 0 " +
                         " and C.City = 'Toronto'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }


            if (CustomFilterBox.Text == "Transactions (Mia)")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R, Branch as B" +
                         " where C.CID = R.CID and B.BID = R.PickupBID and C.MembType = 0 " +
                         " and C.City = 'Miami'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "Branch Fee Members")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and R.PickupBID != R.RetBid and C.MembType = 0 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "GM Late Fee")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and R.ActualRetDate > R.ReturnDate and C.MembType = 1 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }

            if (CustomFilterBox.Text == "Late Fee Members")
            {


                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");


                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and R.ActualRetDate > R.ReturnDate and C.MembType = 0 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");

                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
            }



        }
    }
}
