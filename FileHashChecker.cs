/*
 * Copyright 2024 Nathanne Isip
 * 
 * Permission is hereby granted, free of charge,
 * to any person obtaining a copy of this software
 * and associated documentation files (the “Software”),
 * to deal in the Software without restriction,
 * including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit
 * persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 * 
 * The above copyright notice and this permission notice
 * shall be included in all copies or substantial portions
 * of the Software.
 */

using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace Feihua
{
    public class FileHashChecker
    {
        public bool CheckFileMD5Exists(string filePath, TextBox LogBox)
        {
            LogBox.AppendText("Info: Checking hash of file:\r\n      " + filePath + "\r\n");
            LogBox.SelectionStart = LogBox.TextLength;
            LogBox.ScrollToCaret();

            return HashExistsInDatabase(this.CalculateMD5(filePath), LogBox);
        }

        private string CalculateMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("x2"));
                    }

                    return sb.ToString();
                }
            }
        }

        private bool HashExistsInDatabase(string fileHash, TextBox LogBox)
        {
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=hashes.sqlite3;Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand fmd = connection.CreateCommand())
                    {
                        fmd.CommandText = "SELECT hash FROM hashes WHERE hash = @hash";
                        fmd.CommandType = CommandType.Text;
                        fmd.Parameters.AddWithValue("@hash", fileHash);

                        using (SQLiteDataReader r = fmd.ExecuteReader())
                        {
                            if (r.HasRows)
                            {
                                LogBox.AppendText("Info: Hash found \"" + fileHash + "\"\r\n");
                                LogBox.SelectionStart = LogBox.TextLength;
                                LogBox.ScrollToCaret();

                                return true;
                            }
                            else
                            {
                                LogBox.AppendText("Info: Hash not found \"" + fileHash + "\"\r\n");
                                LogBox.SelectionStart = LogBox.TextLength;
                                LogBox.ScrollToCaret();

                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogBox.AppendText("Error: " + ex.Message + "\r\n");
                LogBox.SelectionStart = LogBox.TextLength;
                LogBox.ScrollToCaret();
            }

            return false;
        }
    }
}
