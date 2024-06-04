using AthleteTrackDAL.DTO_s;
using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL
{
    public class TrainingDAL : ITrainingDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public Training GetTrainingsDetails(int ID)
        {
            Training training = new();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Trainingsschema WHERE ID = @id;");
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                foreach (DbDataRecord record in reader)
                {
                    training.ID = record.GetInt32(0);
                    training.Name = record.GetString(1);
                    training.StartTime = ((TimeSpan)record.GetValue(2)).ToString(@"hh\:mm");
                    training.EndTime = ((TimeSpan)record.GetValue(3)).ToString(@"hh\:mm");
                }
            }
            cmd.Connection.Close();
            ExerciseDAL exercise = new ExerciseDAL();
            training.Exercises = exercise.GetExercises(ID);
            return training;
        }

        public void AddTraining(Training training)
        {
            SqlConnection conn = new(connectionString);
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                SqlCommand cmd = new(
                    "INSERT INTO Trainingsschema (Naam, Begintijd, Eindtijd) " +
                    "VALUES(@name, @starttime, @endtime)", conn, transaction);
                cmd.Parameters.AddWithValue("@name", training.Name);
                cmd.Parameters.AddWithValue("@starttime", training.StartTime);
                cmd.Parameters.AddWithValue("@endtime", training.EndTime);
                cmd.ExecuteNonQuery();
                SqlCommand trainingIDcmd = new("SELECT TOP 1 ID FROM Trainingsschema ORDER BY ID DESC;", conn, transaction);
                int trainingsID = (int)trainingIDcmd.ExecuteScalar();

                foreach (Exercise exercise in training.Exercises)
                {
                    SqlCommand exerciseCmd = new("INSERT INTO TrainingsschemaOefening(Trainingsschema_ID, Oefening_ID, Herhalingen, Tijdsduur) " +
                    "VALUES(@trainingsID, @disciplineID, @repetitions, @time);", conn, transaction);

                    if (exercise.ID == null)
                    {
                        SqlCommand addexerciseCmd = new("INSERT INTO Oefening(Naam, Beschrijving) " +
                        "VALUES(@name, @description); ", conn, transaction);
                        addexerciseCmd.Parameters.AddWithValue("@name", exercise.Name);
                        addexerciseCmd.Parameters.AddWithValue("@description", exercise.Description);
                        addexerciseCmd.ExecuteNonQuery();

                        SqlCommand exerciseIDcmd = new("SELECT TOP 1 ID FROM Oefening ORDER BY ID DESC;", conn, transaction);
                        int exerciseID = (int)exerciseIDcmd.ExecuteScalar();
                        exercise.ID = exerciseID;
                    }

                    exerciseCmd.Parameters.AddWithValue("@trainingsID", trainingsID);
                    exerciseCmd.Parameters.AddWithValue("@disciplineID", exercise.ID);
                    exerciseCmd.Parameters.AddWithValue("@repetitions", exercise.Repetitions);
                    exerciseCmd.Parameters.AddWithValue("@time", exercise.Time);
                    exerciseCmd.ExecuteNonQuery();
                }
                transaction.Commit();
                conn.Close();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                Debug.WriteLine($"Transaction rolled back: {ex}");
            }
        }
    }
}
