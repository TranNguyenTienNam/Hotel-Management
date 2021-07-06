using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Concurrent;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using HotelManagement;

namespace HotelManagement.MVVM.Model
{
    class Process
    {
        public static SqlConnection conn;
        public static SqlDataAdapter da;
        public static SqlCommand cmd;
        public static DataTable data;
        public static SqlDataReader reader;
        //Link connect server chinh sua trong file App.config
        public static string connectLink = ConfigurationManager.ConnectionStrings["con"].ToString();
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";

        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        //Function lấy data từ SQL Server load vào DataTable
        public static DataTable createTable(string sql)
        {
            conn = new SqlConnection(connectLink);
            conn.Open();
            da = new SqlDataAdapter(sql, conn);
            data = new DataTable();
            da.Fill(data);
            conn.Close();
            return data;
        }

        //Function thực hiện câu lệnh SQL Server
        public static int ExecutiveNonQuery(string sql)
        {
            conn = new SqlConnection(connectLink);
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            int rs = cmd.ExecuteNonQuery();
            conn.Close();
            return rs;      //Nếu thực hiện không thành công trả về 0. Ngược lại trả về số hàng bị ảnh hưởng
        }

        //Function thực hiện câu lệnh SQL Server
        public static int ExecutiveReader(string sql)
        {
            int ck = 0;
            conn = new SqlConnection(connectLink);
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)          //reader sẽ đọc những hàng được câu lệnh SQL Server lấy ra từ table
            {
                if (reader.Read() == false) break;
                else
                    ck++;
            }
            conn.Close();
            return ck;      //trả về số hàng đã đọc được. Nếu không có hàng nào thì trả về 0
        }


        public static int insertUser(string sql)
        {
            conn = new SqlConnection(connectLink);
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            int modified = Convert.ToInt32(cmd.ExecuteScalar());
            return modified;

        }

            //Function lấy Ukey từ table
            public static int getNumber(string sql)
        {
            int i = 0;
            conn = new SqlConnection(connectLink);
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                if (reader.Read() == false) break;
                if (!reader.IsDBNull(0))
                {
                    i = reader.GetInt32(0);
                }
            }
            return i;       //trả về Ukey
        }

        public static string getString(string sql)
        {
            string str = "";
            conn = new SqlConnection(connectLink);
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                if (reader.Read() == false) break;
                if (!reader.IsDBNull(0))
                {
                    str = reader.GetString(0);
                }
            }
            return str;       //trả về Ukey
        }

        //Function lấy thông tin của user từ database
        public static user getInfo(string sql)
        {
            user user = new user();
            conn = new SqlConnection(connectLink);
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                if (reader.Read() == false) break;
                if (!reader.IsDBNull(0))
                {
                    user.Ho = reader.GetValue(0).ToString();
                }
                if (!reader.IsDBNull(1))
                {
                    user.Ten = reader.GetValue(1).ToString();
                }
                if (!reader.IsDBNull(2))
                {
                    user.SoDienThoai = reader.GetValue(2).ToString();
                }
                if (!reader.IsDBNull(3))
                {
                    user.GioiTinh = reader.GetValue(3).ToString();
                }
                if (!reader.IsDBNull(4))
                {
                    user.Email = reader.GetValue(4).ToString();
                }
                if (!reader.IsDBNull(5))
                {
                    user.NgaySinh = reader.GetDateTime(5);
                }
                if (!reader.IsDBNull(5))
                {
                    user.QuyenHan = reader.GetValue(6).ToString();
                }
                if (!reader.IsDBNull(5))
                {
                    user.TinhTrangTK = reader.GetValue(7).ToString();
                }
            }
            return user;
        }

        public static bool CheckVietKey(string chuCoDau)
        {
            const string FindText = ":;\"?`!@#$%^&*()~<>[\\]+-_=,.|/ áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            int n;
            int m = chuCoDau.Length;
            char[] arrS = chuCoDau.ToCharArray();
            for (int i = 0; i < m; i++)
            {
                n = FindText.IndexOf(arrS[i]);
                if (n != -1) return false;  //Tìm thấy kí tự có dấu trong dãy FindText
            }
            return true;    //Không tìm thấy kí tự có dấu
        }
    }
}