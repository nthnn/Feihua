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

using System.Data.SQLite;

namespace Feihua
{
    public class UpdaterUtil
    {
        private const int StartIndex = 0;
        private const int EndIndex = 486;

        public UpdaterUtil()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists("hashes.sqlite3"))
            {
                SQLiteConnection.CreateFile("hashes.sqlite3");
            }

            using (var connection = new SQLiteConnection($"Data Source=hashes.sqlite3;Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS hashes (id INTEGER, hash TEXT, PRIMARY KEY(id AUTOINCREMENT))",
                    connection
                )) {
                    command.ExecuteNonQuery();
                }

                string clearTableQuery = $"DELETE FROM hashes";
                using (var command = new SQLiteCommand(clearTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateHashes(Button Btn)
        {
            Task.Run(() =>
            {
                try
                {
                    using (var webClient = new HttpClient())
                    {
                        using (var connection = new SQLiteConnection($"Data Source=hashes.sqlite3;Version=3;"))
                        {
                            connection.Open();

                            for (int i = StartIndex; i <= EndIndex; i++)
                            {
                                string url = string.Format("https://virusshare.com/hashfiles/VirusShare_{0:D5}.md5", i);
                                ProcessContent(webClient.GetStringAsync(url).Result, connection, Btn);

                                int percentage = (int)(((i - StartIndex + 1) / (double)(EndIndex - StartIndex + 1)) * 100);
                                Btn.Invoke(new Action(() => Btn.Text = $"Updating ({percentage}%)"));
                            }
                        }
                    }

                    Btn.Enabled = true;
                    Btn.Invoke(new Action(() => Btn.Text = "Update Database"));
                }
                catch (Exception)
                {
                    Btn.Enabled = true;
                    Btn.Invoke(new Action(() => Btn.Text = "Update Database"));
                }
            });
        }

        private void ProcessContent(string Content, SQLiteConnection Connection, Button Btn)
        {
            using (var transaction = Connection.BeginTransaction())
            {
                try
                {
                    foreach (string line in Content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (!line.StartsWith("#"))
                        {
                            string insertQuery = $"INSERT INTO hashes (hash) VALUES (@hash)";
                            using (var command = new SQLiteCommand(insertQuery, Connection))
                            {
                                command.Parameters.AddWithValue("@hash", line.Trim());
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                }
                catch(Exception Ex)
                {
                    Btn.Enabled = true;
                    Btn.Invoke(new Action(() => Btn.Text = "Update Database"));
                }
            }
        }

        public void ButtonClickHandler(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Text = "Updating (0%)";
                button.Enabled = false;
                UpdateHashes(button);
            }
        }
    }
}
