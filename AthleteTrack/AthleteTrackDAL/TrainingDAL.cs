using AthleteTrackDAL.DTO_s;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL
{
    public class TrainingDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public TrainingDTO GetTrainingsDetails(int ID)
        {
            TrainingDTO training = new();

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
    }
}
