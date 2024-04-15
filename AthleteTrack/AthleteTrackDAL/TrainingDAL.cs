using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthleteTrackLogic.Interfaces;
using AthleteTrackLogic.Classes;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace AthleteTrackDAL
{
    public class TrainingDAL : ITrainingDAL
    {
        public Training GetTrainingsDetails(int ID)
        {
            Training training = new();

            SqlCommand cmd = new SqlCommand($"SELECT * FROM Trainingsschema WHERE ID = {ID}", s);
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
            ExerciseDAL eD = new();
            training.Exercises = eD.GetExercises(ID);
            return training;
        }
    }
}
