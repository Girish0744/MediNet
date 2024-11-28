using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.ComponentModel;

namespace Onana_Hospital_Management_System
{
    //INHERITS FROM CLSINSERT
    class clsUpdate :clsInsert
    {
        
        //Delete Drug from Table By ID
       public void deletingDrugByID(int ID)
        {
            string deleteDrug;
            SqlConnection con;

            // SqlCommand cmd;
            try
            {
                con = new SqlConnection(dbPath);
                con.Open();
                deleteDrug = "delete  from  tblProduct where proCode =@proCode";
                SqlCommand cmd = new SqlCommand(deleteDrug, con);
                try
                {
                    cmd.Parameters.AddWithValue("@proCode", ID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Product deleted successfully", "Delete Product - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Product Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       public  void BackUp()
        { 
        try{
           
          SqlConnection  con = new SqlConnection(dbPath);
            con.Open(); //OPEN ACCESS TO DATABASE
           SqlCommand cmd =  new SqlCommand(dbPath, con);

            //CREATE DIRECTORY IF NOT EXIST
           if (!Directory.Exists(@"C:\Temp_dbOHMS")) 
		{
                Directory.CreateDirectory(@"C:\Temp_dbOHMS");
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "BACKUP DATABASE dbOHMS TO DISK = 'C:\\Temp_dbOHMS\\dbOHMS.BAK'";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                MessageBox.Show(@"database backup successfully to C:\Temp_dbOHMS\dbOHMS.BAK", "Backup Database - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

               
		}
            else
		{
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "BACKUP DATABASE dbOHMS TO DISK = 'C:\\Temp_dbOHMS\\dbOHMS.BAK'";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show(@"database backup successfully to C:\Temp_dbOHMS\dbOHMS.BAK", "Backup Database - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
          	 }
          }  
        catch (Exception ex )
        {
            MessageBox.Show(ex.Message + Environment.NewLine + "Please contact the developer", " Database Backup Error- Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
        }
            

        
        
        }

       public void UpdateProductQty(string names, int qty)
       {
           try
           {
               SqlConnection con = new SqlConnection(dbPath);
               con.Open();
               string sql = "Update tblProduct set  proQty=@proQty where proName =@proName";
               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.Parameters.AddWithValue("@proName", names.Trim());
               cmd.Parameters.AddWithValue("@proQty", qty);
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               //MessageBox.Show(ex.Message);
           }
       }
     
    }
}
