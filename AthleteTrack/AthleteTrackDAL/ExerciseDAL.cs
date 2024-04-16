using AthleteTrackDAL.DTO_s;
using Microsoft.Data.SqlClient;

namespace AthleteTrackDAL
{
    public class ExerciseDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public List<ExerciseDTO> GetExercises(int ID)
        {
            List<ExerciseDTO> exercises = new();

            SqlCommand cmd = new();

            cmd.CommandText = 
                "SELECT Trainingsschema.ID, TrainingsschemaOefening.Tijdsduur, Oefening.Naam, Oefening.Beschrijving, TrainingsschemaOefening.Herhalingen, TrainingsschemaOefening.Oefening_ID " +
                $"FROM Trainingsschema " +
                $"INNER JOIN TrainingsschemaOefening ON TrainingsschemaOefening.Trainingsschema_ID = Trainingsschema.ID\r\nINNER JOIN Oefening ON TrainingsschemaOefening.Oefening_ID = Oefening.ID " +
                $"WHERE Trainingsschema_ID = @id";
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Connection = new SqlConnection(connectionString);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ExerciseDTO e = new();
                e.Name = reader.GetString(2);
                e.Description = reader.GetString(3);
                e.Repetitions = reader.GetInt32(4);
                e.Time = ((TimeSpan)reader.GetValue(1)).ToString(@"hh\:mm");
                e.ID = reader.GetInt32(5);

                exercises.Add(e);
            }
            return exercises;
        }
    }
}
