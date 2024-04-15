using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;
using Microsoft.Data.SqlClient;

namespace AthleteTrackDAL
{
    public class ExerciseDAL : IExerciseDAL
    {
        public List<Exercise> GetAllExercises()
        {
            List<Exercise> exercise = new();

            SqlCommand cmd = new SqlCommand($"SELECT Oefening.Naam, Oefening.ID, Oefening.Beschrijving \r\nFROM Oefening", s);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Exercise o = new(reader.GetString(0), reader.GetString(2), 0, "00:00", reader.GetInt32(1));
                exercise.Add(o);
            }
            return exercise;
        }

        public List<Exercise> GetExercises(int ID)
        {
            List<Exercise> exercises = new();

            SqlCommand cmd = new SqlCommand($"SELECT Trainingsschema.ID, TrainingsschemaOefening.Tijdsduur, Oefening.Naam, Oefening.Beschrijving, TrainingsschemaOefening.Herhalingen, TrainingsschemaOefening.Oefening_ID\r\nFROM Trainingsschema\r\nINNER JOIN TrainingsschemaOefening ON TrainingsschemaOefening.Trainingsschema_ID = Trainingsschema.ID\r\nINNER JOIN Oefening ON TrainingsschemaOefening.Oefening_ID = Oefening.ID\r\nWHERE Trainingsschema_ID = {ID}", s);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Exercise e = new(reader.GetString(2), reader.GetString(3), reader.GetInt32(4), ((TimeSpan)reader.GetValue(1)).ToString(@"hh\:mm"), reader.GetInt32(5));
                exercises.Add(e);
            }
            return exercises;
        }
    }
}
