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

            //Get the starting date and ending date from user
            DateTime EmpFrom = EmpDateFrom.Value.Date; 
            DateTime EmpTo = EmpDateTo.Value.Date;     


            //Which Employee sold the most units
            if (EmpFilterBox.Text == "Most Sold (Units)")
            {
                //Clear and add new columns
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");
                EmpRepTable.Columns.Add("Amount", "Total");

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct E_FName, E_LName, E_Email, COUNT(P.TID) as Total" +
                         " from Employee as E, Process as P, RentalTrans as R" +
                         " where E.EID = P.EID and R.TID = P.TID" + 
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " group by E_FName, E_LName, E_Email" +
                         " order by Total DESC");

                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(), 
                                         D2.myReader["E_LName"].ToString(), 
                                         D2.myReader["E_Email"], 
                                         D2.myReader["Total"].ToString());
                }
                D2.myReader.Close();

                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (EmpFilterBox.Text == "All Employees")
            {
                //Clear and add new columns
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");
                EmpRepTable.Columns.Add("Branch", "Branch");
                EmpRepTable.Columns.Add("Name", "BranchName");


                //SQL query to filter out and get the result we are looking for.
                D2.query(" select *" +
                         " from Employee as E, Branch as B" +
                         " where E.BID = B.BID");

                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"],
                                         D2.myReader["BID"],
                                         D2.myReader["Name"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (EmpFilterBox.Text == "Most Sold ($)")
            {
                //Clear and add new columns
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");
                EmpRepTable.Columns.Add("Amount", "TotalPrice");

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct E_FName,E_LName, E_Email, sum(Cost) as TotalPrice" +
                         " from Employee as E, Process as P, RentalTrans as R" + 
                         " where E.EID = P.EID and R.TID = P.TID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + EmpFrom + "')" +
                         " and convert(smalldatetime, " + "'" + EmpTo + "')" +
                         " group by E_FName, E_LName, E_Email" +
                         " order by TotalPrice DESC");

                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"],
                                         D2.myReader["TotalPrice"].ToString());
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (EmpFilterBox.Text == "Only Sold to GM")
            {
                //Clear and add new columns
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);                                     
                }


                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }
            else if (EmpFilterBox.Text == "Only Edm Cust")
            {
                //Clear and add new columns
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }
            else if (EmpFilterBox.Text == "Sold Only Sedans")
            {
                //Clear and add new columns
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }
            else if (EmpFilterBox.Text == "Sold Only SUV's")
            {
                //Clear and add new columns
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }
            else if (EmpFilterBox.Text == "Sold Only Minivan's")
            {
                //Clear and add new columns
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }
            else if (EmpFilterBox.Text == "Sold Only Luxury's")
            {
                //Clear and add new columns
                EmpRepTable.Columns.Clear();
                EmpRepTable.Columns.Add("FName", "EFName");
                EmpRepTable.Columns.Add("LName", "ELName");
                EmpRepTable.Columns.Add("Email", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["E_FName"].ToString(),
                                         D2.myReader["E_LName"].ToString(),
                                         D2.myReader["E_Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }
        }

        private void CustRepButt_Click(object sender, EventArgs e)
        {
            //Get the starting date and ending date from user
            DateTime CustFrom = CustDateFrom.Value.Date;
            DateTime CustTo = CustDateTo.Value.Date;

            if (CustFilterBox.Text == "Most Transactions")
            {
                //Clear and add new columns
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");
                CustRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct FName,LName, Email, COUNT(TID) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " group by FName, LName, Email" +
                         " order by Total DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"],
                                         D2.myReader["Total"].ToString());
                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (CustFilterBox.Text == "All Customers")
            {
                //Clear and add new columns
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "GoldMember");
                CustRepTable.Columns.Add("Email", "Email");
                CustRepTable.Columns.Add("City", "City");
                CustRepTable.Columns.Add("Street1", "Street1");
                CustRepTable.Columns.Add("Street2", "Street2");
                CustRepTable.Columns.Add("PostalCode", "PostalCode");

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select *" +
                         " from Customer as C");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (CustFilterBox.Text == "Most Amount ($)")
            {
                //Clear and add new columns
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");
                CustRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
                D2.query("select distinct FName, LName, Email, sum(Cost) as TotalPrice" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " group by FName, LName, Email" +
                         " order by TotalPrice DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"],
                                         D2.myReader["TotalPrice"].ToString());
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (CustFilterBox.Text == "Upgraded Customers")
            {
                //Clear and add new columns
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct FName,LName, Email" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 0" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " group by FName, LName, Email" +
                         " having count(C.CID) > 3");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (CustFilterBox.Text == "Bought Only Sedans")
            {
                //Clear and add new columns
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }


            else if (CustFilterBox.Text == "Bought Only SUV's")
            {
                //Clear and add new columns
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }



            else if (CustFilterBox.Text == "Bought Only Minivan's")
            {
                //Clear and add new columns
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (CustFilterBox.Text == "Bought Only Luxury's")
            {
                //Clear and add new columns
                CustRepTable.Columns.Clear();
                CustRepTable.Columns.Add("FName", "FName");
                CustRepTable.Columns.Add("LName", "LName");
                CustRepTable.Columns.Add("Membership", "Email");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustRepTable.Rows.Add(D2.myReader["FName"].ToString(),
                                         D2.myReader["LName"].ToString(),
                                         D2.myReader["Email"]);
                }

                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

        }

        private void BranchRepButt_Click(object sender, EventArgs e)
        {
            //Get the starting date and ending date from user
            DateTime BranchFrom = BranchDateFrom.Value.Date;
            DateTime BranchTo = BranchDateTo.Value.Date;

            if (BranchFilterBox.Text == "All Branches")
            {
                //Clear and add new columns
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

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select *" +
                         " from Branch as B");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (BranchFilterBox.Text == "Most Transactions")
            {
                //Clear and add new columns
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

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode, Count(TID) as Total" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, B.[Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode" +
                         " order by Total DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (BranchFilterBox.Text == "Most Amount ($)")
            {
                //Clear and add new columns
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

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode, sum(Cost) as TotalPrice" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, B.[Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode" +
                         " order by TotalPrice DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (BranchFilterBox.Text == "Dealt With GM")
            {
                //Clear and add new columns
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

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (BranchFilterBox.Text == "Deal With Non GM")
            {
                //Clear and add new columns
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

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (BranchFilterBox.Text == "Most Sedans")
            {
                //Clear and add new columns
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

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode, COUNT(CT_ID) as totSedan" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID and CT_ID = '001'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " order by totSedan DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (BranchFilterBox.Text == "Most SUV's")
            {
                //Clear and add new columns
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

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode, COUNT(CT_ID) as totSuv" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID and CT_ID = '002'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " order by totSuv DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (BranchFilterBox.Text == "Most Minivan's")
            {
                //Clear and add new columns
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

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode, COUNT(CT_ID) as totMini" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID and CT_ID = '003'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " order by totMini DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            else if (BranchFilterBox.Text == "Most Luxury's")
            {
                //Clear and add new columns
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

                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode, COUNT(CT_ID) as totLux" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID and CT_ID = '004'" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + BranchFrom + "')" +
                         " and convert(smalldatetime, " + "'" + BranchTo + "')" +
                         " group by BID, [Name], B_PhoneNo, B_Email, Province, B.City, B.[Street 1], B.[Street 2], B.PostalCode" +
                         " order by totLux DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

        }

        private void CustomRepButt_Click(object sender, EventArgs e)
        {
            //Get the starting date and ending date from user as well as
            //what pickup branch we want to specify as well as the amount 
            //To add onto the filters
            DateTime CustFrom = CustomDateFrom.Value.Date;
            DateTime CustTo = CustomDateTo.Value.Date;
            string BranchDecision = BranchPick.Text.Split()[0];
            decimal AmountWritten = Convert.ToDecimal(AmtTextBox.Text);


            if (CustomFilterBox.Text == "Branch Revenue")
            {

                //Clear and add new columns
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


                //SQL query to filter out and get the result we are looking for.
                D2.query(" select distinct BID, [Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode, sum(Cost) as TotalPrice" +
                         " from Branch as B, RentalTrans as R" +
                         " where B.BID = R.PickUpBID" +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +                
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by BID, B.[Name], B_PhoneNo, B_Email, Province, City, [Street 1], [Street 2], PostalCode" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by TotalPrice DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
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
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Transactions")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 1 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());
                                           
                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "Transactions")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
                D2.query("select distinct TID, C.CID, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and C.MembType = 0 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Purchase (Sedan)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Purchase (SUV)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Purchase (Minivan)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Purchase (Luxury)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "Purchase (Sedan)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }


            if (CustomFilterBox.Text == "Purchase (SUV)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }


            if (CustomFilterBox.Text == "Purchase (Minivan)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }


            if (CustomFilterBox.Text == "Purchase (Luxury)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Transactions (Edm)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }
            if (CustomFilterBox.Text == "GM Transactions (Edm)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Transactions (Van)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Transactions (Tor)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Transactions (Mia)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "Transactions (Edm)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "Transactions (Van)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "Transactions (Tor)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }


            if (CustomFilterBox.Text == "Transactions (Mia)")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
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


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "Branch Fee Members")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and R.PickupBID != R.RetBid and C.MembType = 0 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "GM Late Fee")
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and R.ActualRetDate > R.ReturnDate and C.MembType = 1 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query
            }

            if (CustomFilterBox.Text == "Late Fee Members") 
            {

                //Clear and add new columns
                CustomRepTable.Columns.Clear();
                CustomRepTable.Columns.Add("BID", "TID");
                CustomRepTable.Columns.Add("Name", "CID");
                CustomRepTable.Columns.Add("Email", "Email");
                CustomRepTable.Columns.Add("PhoneNum", "Total");

                //SQL query to filter out and get the result we are looking for.
                D2.query("select distinct TID, C.CID, C.Email, sum(Cost) as Total" +
                         " from Customer as C, RentalTrans as R" +
                         " where C.CID = R.CID and R.ActualRetDate > R.ReturnDate and C.MembType = 0 " +
                         " and R.PickupDate between convert(smalldatetime, " + "'" + CustFrom + "')" +
                         " and convert(smalldatetime, " + "'" + CustTo + "')" +
                         " and R.PickUpBID = '" + BranchDecision.Trim() + "'" +
                         " group by TID, C.CID, C.Email" +
                         " having sum(Cost) > " + AmountWritten +
                         " order by Total DESC");


                //The while loop will go through the entire table
                //and fill in the respective values that need to 
                //be inserted into the table 
                while (D2.myReader.Read())
                {
                    CustomRepTable.Rows.Add(D2.myReader["TID"].ToString(),
                                            D2.myReader["CID"].ToString(),
                                            D2.myReader["Email"],
                                            D2.myReader["Total"].ToString());

                }
                D2.myReader.Close();
                //After we fill in the tables, we will tell
                //the reader to clsoe the database so that no overlap
                //Will occur and that the user can go onto the next query

            }
        }
    }
}
