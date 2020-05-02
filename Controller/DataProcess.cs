using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SampleApp.Controller
{
    public class DataProcess
    {
        public static DataTable Login(string username, string password)
        {
            using (SQLProcess.SqlCommandEx _sql = new SQLProcess.SqlCommandEx(@"UserLogin"))
            {
                _sql.CommandObject.CommandType = CommandType.StoredProcedure;

                _sql.CommandObject.Parameters.AddWithValue("@username", PubFunc.Encrypt(username));
                _sql.CommandObject.Parameters.AddWithValue("@password", PubFunc.Encrypt(password));

                DataTable _dt = new DataTable();
                _dt = _sql.GetDataTable();
                _dt.TableName = "dtmain";
                return _dt;
            }
        }

        public static DataTable LoadBank(string id, string inputs)
        {
            string[] input = inputs.Split('▲');
            string keyword = input[0];
            string dateFrom = input[1];
            string dateTo = input[2];

            using (SQLProcess.SqlCommandEx _sql = new SQLProcess.SqlCommandEx(@"BankLoad"))
            {
                _sql.CommandObject.CommandType = CommandType.StoredProcedure;

                _sql.CommandObject.Parameters.AddWithValue("@id", id);
                _sql.CommandObject.Parameters.AddWithValue("@keyword", keyword);
                _sql.CommandObject.Parameters.AddWithValue("@dateFrom", dateFrom);
                _sql.CommandObject.Parameters.AddWithValue("@dateto", dateTo);

                DataTable _dt = new DataTable();
                _dt = _sql.GetDataTable();
                _dt.TableName = "dtBank";
                return _dt;
            }
        }

        public static string SaveUpdateBank(bool isEdit, string inputs)
        {
            string[] input = inputs.Split('▲');
            string id = input[0];
            string name = input[1];
            string isActive = input[2];


            using (SQLProcess.SqlCommandEx _sql = new SQLProcess.SqlCommandEx(@"BankSaveUpdate"))
            {
                _sql.CommandObject.CommandType = CommandType.StoredProcedure;

                _sql.CommandObject.Parameters.AddWithValue("@isEdit", isEdit);
                _sql.CommandObject.Parameters.AddWithValue("@id", id);
                _sql.CommandObject.Parameters.AddWithValue("@name", name);
                _sql.CommandObject.Parameters.AddWithValue("@isActive", isActive);
                _sql.CommandObject.ExecuteNonQuery();

                if (isEdit)
                {
                    return "Updated Successfully";
                }
                else
                {
                    return "Saved Successfully";
                }
            }
        }

        public static DataTable LoadBranch(string id, string inputs)
        {
            string[] input = inputs.Split('▲');
            string keyword = input[0];
            string dateFrom = input[1];
            string dateTo = input[2];

            using (SQLProcess.SqlCommandEx _sql = new SQLProcess.SqlCommandEx(@"BankBranchLoad"))
            {
                _sql.CommandObject.CommandType = CommandType.StoredProcedure;

                _sql.CommandObject.Parameters.AddWithValue("@id", id);
                _sql.CommandObject.Parameters.AddWithValue("@keyword", keyword);
                _sql.CommandObject.Parameters.AddWithValue("@dateFrom", dateFrom);
                _sql.CommandObject.Parameters.AddWithValue("@dateto", dateTo);

                DataTable _dt = new DataTable();
                _dt = _sql.GetDataTable();
                _dt.TableName = "dtBranch";
                return _dt;
            }
        }
        public static string SaveUpdateBankDetails(bool isEdit, string inputs)
        {
            string[] input = inputs.Split('▲');
            string id = input[0];
            string name = input[1];
            string isActive = input[2];
            string bankId = input[3];
            string accountNo = input[4];


            using (SQLProcess.SqlCommandEx _sql = new SQLProcess.SqlCommandEx(@"BankBranchSaveUpdate"))
            {
                _sql.CommandObject.CommandType = CommandType.StoredProcedure;

                _sql.CommandObject.Parameters.AddWithValue("@isEdit", isEdit);
                _sql.CommandObject.Parameters.AddWithValue("@id", id);
                _sql.CommandObject.Parameters.AddWithValue("@name", name);
                _sql.CommandObject.Parameters.AddWithValue("@isActive", isActive);
                _sql.CommandObject.Parameters.AddWithValue("@bankId", bankId);
                _sql.CommandObject.Parameters.AddWithValue("@accountNo", accountNo);
                _sql.CommandObject.ExecuteNonQuery();

                if (isEdit)
                {
                    return "Updated Successfully";
                }
                else
                {
                    return "Saved Successfully";
                }
            }
        }
        public static DataTable LoadPayment(string id, string inputs)
        {
            string[] input = inputs.Split('▲');
            string keyword = input[0];
            string dateFrom = input[1];
            string dateTo = input[2];

            using (SQLProcess.SqlCommandEx _sql = new SQLProcess.SqlCommandEx(@"PaymentDetailsLoad"))
            {
                _sql.CommandObject.CommandType = CommandType.StoredProcedure;

                _sql.CommandObject.Parameters.AddWithValue("@id", id);
                _sql.CommandObject.Parameters.AddWithValue("@keyword", keyword);
                _sql.CommandObject.Parameters.AddWithValue("@dateFrom", dateFrom);
                _sql.CommandObject.Parameters.AddWithValue("@dateto", dateTo);

                DataTable _dt = new DataTable();
                _dt = _sql.GetDataTable();
                _dt.TableName = "dtBranch";
                return _dt;
            }
        }
        public static string SaveUpdatePaymentDetails(bool isEdit, string inputs)
        {
            string[] input = inputs.Split('▲');
            string id = input[0];
            string name = input[1];
            string isActive = input[2];
            string defaultAmount = input[3]; 


            using (SQLProcess.SqlCommandEx _sql = new SQLProcess.SqlCommandEx(@"PaymentDetailsSaveUpdate"))
            {
                _sql.CommandObject.CommandType = CommandType.StoredProcedure;

                _sql.CommandObject.Parameters.AddWithValue("@isEdit", isEdit);
                _sql.CommandObject.Parameters.AddWithValue("@id", id);
                _sql.CommandObject.Parameters.AddWithValue("@name", name);
                _sql.CommandObject.Parameters.AddWithValue("@isActive", isActive); 
                _sql.CommandObject.Parameters.AddWithValue("@defaultPayment", defaultAmount);
                _sql.CommandObject.ExecuteNonQuery();

                if (isEdit)
                {
                    return "Updated Successfully";
                }
                else
                {
                    return "Saved Successfully";
                }
            }
        }


    }
}