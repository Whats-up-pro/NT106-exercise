using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Bai7_Server.Models;

namespace Bai7_Server.Database
{
    public class DatabaseHelper
    {
        private string connectionString;
        private string dbPath;

        public DatabaseHelper(string databasePath = "ServerDatabase.db")
        {
            dbPath = databasePath;
            connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            bool isNewDatabase = !File.Exists(dbPath);

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Tạo bảng NguoiDung
                string createNguoiDungTable = @"
                    CREATE TABLE IF NOT EXISTS NguoiDung (
                        IDNCC INTEGER PRIMARY KEY AUTOINCREMENT,
                        HoVaTen TEXT NOT NULL,
                        QuyenHan TEXT NOT NULL
                    )";

                using (SQLiteCommand cmd = new SQLiteCommand(createNguoiDungTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Tạo bảng MonAn
                string createMonAnTable = @"
                    CREATE TABLE IF NOT EXISTS MonAn (
                        IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
                        TenMonAn TEXT NOT NULL,
                        HinhAnh TEXT,
                        IDNCC INTEGER,
                        FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC)
                    )";

                using (SQLiteCommand cmd = new SQLiteCommand(createMonAnTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Thêm dữ liệu mẫu nếu là database mới
                if (isNewDatabase)
                {
                    InsertSampleData(conn);
                }
            }
        }

        private void InsertSampleData(SQLiteConnection conn)
        {
            // Thêm người dùng mẫu
            string[] nguoiDung = {
                "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES ('Admin', 'Admin')",
                "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES ('Nguyễn Văn A', 'User')",
                "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES ('Trần Thị B', 'User')"
            };

            foreach (string sql in nguoiDung)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            // Thêm món ăn mẫu
            string[] monAn = {
                "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES ('Phở Bò', 'pho_bo.jpg', 1)",
                "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES ('Bún Chả', 'bun_cha.jpg', 1)",
                "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES ('Cơm Tấm', 'com_tam.jpg', 2)"
            };

            foreach (string sql in monAn)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<NguoiDung> GetAllNguoiDung()
        {
            List<NguoiDung> list = new List<NguoiDung>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT IDNCC, HoVaTen, QuyenHan FROM NguoiDung";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NguoiDung
                        {
                            IDNCC = reader.GetInt32(0),
                            HoVaTen = reader.GetString(1),
                            QuyenHan = reader.GetString(2)
                        });
                    }
                }
            }

            return list;
        }

        public int AddNguoiDung(NguoiDung nguoiDung)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES (@HoVaTen, @QuyenHan); SELECT last_insert_rowid();";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@HoVaTen", nguoiDung.HoVaTen);
                    cmd.Parameters.AddWithValue("@QuyenHan", nguoiDung.QuyenHan);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public List<MonAn> GetAllMonAn()
        {
            List<MonAn> list = new List<MonAn>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT IDMA, TenMonAn, HinhAnh, IDNCC FROM MonAn";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MonAn
                        {
                            IDMA = reader.GetInt32(0),
                            TenMonAn = reader.GetString(1),
                            HinhAnh = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            IDNCC = reader.GetInt32(3)
                        });
                    }
                }
            }

            return list;
        }

        public List<MonAn> GetMonAnByUser(int idncc)
        {
            List<MonAn> list = new List<MonAn>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT IDMA, TenMonAn, HinhAnh, IDNCC FROM MonAn WHERE IDNCC = @IDNCC";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDNCC", idncc);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new MonAn
                            {
                                IDMA = reader.GetInt32(0),
                                TenMonAn = reader.GetString(1),
                                HinhAnh = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                IDNCC = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }

            return list;
        }

        public void AddMonAn(MonAn monAn)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@TenMonAn, @HinhAnh, @IDNCC)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenMonAn", monAn.TenMonAn);
                    cmd.Parameters.AddWithValue("@HinhAnh", monAn.HinhAnh ?? "");
                    cmd.Parameters.AddWithValue("@IDNCC", monAn.IDNCC);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public NguoiDung GetNguoiDungById(int idncc)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT IDNCC, HoVaTen, QuyenHan FROM NguoiDung WHERE IDNCC = @IDNCC";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDNCC", idncc);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new NguoiDung
                            {
                                IDNCC = reader.GetInt32(0),
                                HoVaTen = reader.GetString(1),
                                QuyenHan = reader.GetString(2)
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
