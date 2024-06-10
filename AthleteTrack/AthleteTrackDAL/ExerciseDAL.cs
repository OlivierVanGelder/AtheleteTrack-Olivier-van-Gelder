using AthleteTrackDAL.DTO_s;
using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace AthleteTrackDAL
{
    public class ExerciseDAL : IExerciseDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public List<Exercise> GetExercises(int ID)
        {
            List<Exercise> exercises = new();

            SqlCommand cmd = new();

            cmd.CommandText = 
                "SELECT Trainingsschema.ID, TrainingsschemaOefening.Tijdsduur, Oefening.Naam, Oefening.Beschrijving, TrainingsschemaOefening.Herhalingen, TrainingsschemaOefening.Oefening_ID " +
                $"FROM Trainingsschema " +
                $"INNER JOIN TrainingsschemaOefening ON TrainingsschemaOefening.Trainingsschema_ID = Trainingsschema.ID\r\nINNER JOIN Oefening ON TrainingsschemaOefening.Oefening_ID = Oefening.ID " +
                $"WHERE Trainingsschema_ID = @id";
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Exercise e = new();
                e.Name = reader.GetString(2);
                e.Description = reader.GetString(3);
                e.Repetitions = reader.GetInt32(4);
                e.Time = ((TimeSpan)reader.GetValue(1)).ToString(@"hh\:mm");
                e.ID = reader.GetInt32(5);

                exercises.Add(e);
            }
            cmd.Connection.Close();
            return exercises;
        }

        public List<Exercise> GetAllExercises()
        {
            List<Exercise> exercises = new();

            SqlCommand cmd = new();

            cmd.CommandText =
                "SELECT [ID], [Naam], [Beschrijving]" +
                "FROM [dbi536130_athletet].[dbo].[Oefening]";            
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Exercise e = new();
                e.Name = reader.GetString(1);
                e.Description = reader.GetString(2);
                e.Repetitions = 1;
                e.Time = "";
                e.ID = reader.GetInt32(0);
                exercises.Add(e);
            }
            cmd.Connection.Close();
            return exercises;
        }

        public void AddExercise(Exercise exercise)
        {
            SqlConnection conn = new(connectionString);
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                SqlCommand exercideCMD = new("INSERT INTO Oefening(Naam, Beschrijving) VALUES (@Name, @Description);", conn);
                exercideCMD.Parameters.AddWithValue("@Name", exercise.Name);
                exercideCMD.Parameters.AddWithValue("@Desciption", exercise.Description);
                exercideCMD.Transaction = transaction;
                exercideCMD.ExecuteNonQuery();

                conn.Close();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                Debug.WriteLine("Transaction rolled back");
            }
        }
    }
}
