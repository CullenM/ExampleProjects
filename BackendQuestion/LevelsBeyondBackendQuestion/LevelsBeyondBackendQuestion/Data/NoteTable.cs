using System;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using LevelsBeyondBackendQuestion.Models;

namespace LevelsBeyondBackendQuestion.Data
{
    public static class NoteTable
    {
        private static SQLiteConnection connection;

        public static bool CreateDatabase()
        {
            string dbFilePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\notes.db";
            try
            {
                if (!File.Exists(dbFilePath))
                {
                    SQLiteConnection.CreateFile(dbFilePath);
                }
                connection = new SQLiteConnection("DataSource=" + dbFilePath);
                connection.Open();
                CreateTable();
            }
            catch (SQLiteException)
            {
                return false;
            }
            return true;
        }

        private static void CreateTable()
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Notes" +
                    " (id INTEGER PRIMARY KEY AUTOINCREMENT, body TEXT);";
                command.ExecuteNonQuery();
            }
        }

        public static Note InsertNote(string body)
        {
            long lastId;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "INSERT INTO Notes (body) VALUES ('" + body + "');";
                command.ExecuteNonQuery();

                command.CommandText = @"select last_insert_rowid()";
                lastId = (long)command.ExecuteScalar();
            }
            return new Note { Id = (int)lastId, Body=body };
        }

        public static Note GetNoteById(int id)
        {
            Note note = null;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT * FROM Notes WHERE id = " + id + ";";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    note = new Note { Id = reader.GetInt32(0), Body = reader.GetString(1) };
                }
            }
            return note;
        }

        public static List<Note> GetNoteByBody(string body)
        {
            List<Note> notes = new List<Note>();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT * FROM Notes WHERE body LIKE '%"+body+"%';";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    notes.Add(new Note { Id = reader.GetInt32(0), Body = reader.GetString(1) });
                }
            }
            return notes;
        }

        public static List<Note> GetNotes()
        {
            List<Note> notes = new List<Note>();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT * FROM Notes;";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    notes.Add(new Note { Id = reader.GetInt32(0), Body = reader.GetString(1)});
                }
            }
            return notes;
        }
    }
}