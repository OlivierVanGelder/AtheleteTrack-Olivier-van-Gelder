using AthleteTrackMVC.Models;
using AthleteTrackLogic;
using AthleteTrackLogic.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AthleteTrackDAL;

namespace AthleteTrack.Controllers
{
    public class SchemapagesController : Controller
    {
        IConfiguration _configuration;

        private readonly ILogger<SchemapagesController> _logger;

        public SchemapagesController(ILogger<SchemapagesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Trainingsschema(int ID, int ExerciseID)
        {
            TrainingLogic trainingLogic = new TrainingLogic();
            TrainingsPageModel model = new();
            TrainingDAL trainingDAL = new TrainingDAL();
            Training training = trainingLogic.GetTraining(ID, trainingDAL);
            model.ID = training.ID;
            model.StartTime = training.StartTime;
            model.EndTime = training.EndTime;
            model.Name = training.Name;
            model.Exercises = training.Exercises;
            if (ExerciseID != 0)
            {
                model.ExerciseID = ExerciseID;
            }
            return View(model);
        }

        public IActionResult Wedstrijdschema(int ID, int DisciplineID)
        {
            AtleetLogic atleetLogic = new();
            EventLogic eventLogic = new();
            AthleteDAL athleteDAL = new AthleteDAL();
            EventPageModel model = new();
            EventDAL eventDal = new();
            Event @event = eventLogic.GetEvent(ID, eventDal);
            model.ID = @event.ID;
            model.StartTime = @event.StartTime;
            model.EndTime = @event.EndTime;
            model.Name = @event.Name;
            model.Date = @event.Date;
            model.Disciplines = @event.Disciplines;
            model.Atleten = new();
            if (DisciplineID != 0)
            {
                model.Atleten = atleetLogic.GetAtleten(DisciplineID, athleteDAL);
                model.OnderdeelID = DisciplineID;
            }
            return View(model);
        }

        public IActionResult CreateWedstrijdschema()
        {
            CreateEventPageModel model = new();
            EventLogic eventLogic = new();
            DisciplinesDAL disciplinesDal = new();

            model.Disciplines = eventLogic.GetAllDisciplines(disciplinesDal);
            model.SelectedDisciplines.Add(new Discipline { Name = "60m sprint", StartTime = "00:00", EndTime = "00:00", Athletes = new() });
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateWedstrijdschema(CreateEventPageModel model)
        {
            EventLogic eventLogic = new();
            DisciplinesDAL disciplinesDal = new();

            model.Disciplines = eventLogic.GetAllDisciplines(disciplinesDal);
            if(model.Action == "New")
                model.SelectedDisciplines.Add(new Discipline { Name = "", StartTime = "00:00", EndTime = "00:00", Athletes = new() });

            if (model.Action == "Save")
            {
                foreach (var discipline in model.SelectedDisciplines)
                {
                    if (discipline.SelectedAthlete != null && discipline.SelectedAthlete.Trim() != "")
                    {
                        discipline.Athletes.Add(new Athlete {Name = discipline.SelectedAthlete});
                    }
                }
            } 

            if (model.Action == "Submit")
            {
                if (string.IsNullOrWhiteSpace(model.Date) || string.IsNullOrWhiteSpace(model.EndTime) || string.IsNullOrWhiteSpace(model.StartTime) || string.IsNullOrWhiteSpace(model.Name))
                {
                    model.ErrorMessage = "Voer alle velden in A.U.B.";
                    return View(model);
                }

                Event @event = new();
                EventDAL eventDAL = new();

                @event.StartTime = model.StartTime;
                @event.EndTime = model.EndTime;
                if(model.Date != null)
                {
                    string[] date = model.Date.Split("-");
                    try
                    {
                        model.Date = date[0] + "-";
                        model.Date += date[1] + "-";
                        model.Date += date[2];
                    }catch(Exception) { }
                }
                @event.Date = model.Date;
                @event.Name = model.Name;

                foreach (var selecteddiscipline in model.SelectedDisciplines)
                {
                    foreach(var discipline in model.Disciplines)
                    {
                        if(discipline.Name == selecteddiscipline.Name)
                        {
                            selecteddiscipline.ID = discipline.ID;
                        }
                    }
                }

                model.ErrorMessage = null;
                model.SuccesMessage = null;
                @event.Disciplines = model.SelectedDisciplines;

                try
                {
                    if (!eventLogic.AddEvent(@event, eventDAL))
                    {
                        model.ErrorMessage = "Wedstrijd toevoegen mislukt!";
                        return View(model);
                    }
                    else
                    {
                        model.SuccesMessage = "Wedstrijdschema is toegevoegd!";
                        return View(model);
                    }
                }
                catch (ArgumentException)
                {
                    model.ErrorMessage = "Voer alle lege velden in A.U.B.";
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult CreateTrainingsschema()
        {
            CreateTrainingPageModel model = new();
            TrainingLogic trainingLogic = new();
            ExerciseDAL exerciseDAL = new ExerciseDAL();
            model.Exercises = trainingLogic.GetAllExercises(exerciseDAL);
            model.SelectedExercises = new()
            {
                new Exercise { Name = "Pushups" }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateTrainingsschema(CreateTrainingPageModel model)
        {
            TrainingLogic trainingLogic = new();
            ExerciseDAL exerciseDAL = new ExerciseDAL();
            TrainingDAL trainingDAL = new TrainingDAL();
            model.Exercises = trainingLogic.GetAllExercises(exerciseDAL);
            if (model.Action == "New")
                model.SelectedExercises.Add(new Exercise { Name = "Pushup"});

            if (model.Action == "Submit")
            {
                Training training = new();

                training.StartTime = model.StartTime;
                training.EndTime = model.EndTime;
                training.Name = model.Name;

                foreach(var selectedexercise in model.SelectedExercises)
                {
                    foreach(var exercise in model.Exercises)
                    {
                        if(exercise.Name == selectedexercise.Name)
                        {
                            selectedexercise.ID = exercise.ID;
                        }
                    }
                }

                training.Exercises = model.SelectedExercises;
                try
                {
                    if (!trainingLogic.AddTraining(training, trainingDAL))
                    {
                        model.ErrorMessage = "Voer alle lege velden in A.U.B. (geen negatieve getallen)";
                        return View(model);
                    }
                    else
                    {
                        model.SuccesMessage = "Trainingsschema is toegevoegd!";
                        return View(model);
                    }
                }
                catch (ArgumentException)
                {
                    model.ErrorMessage = "Voer alle lege velden in A.U.B. (geen negatieve getallen)";
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult NewExercise()
        {
            NewExerciseModel model = new();
            model.NewExercise = new();
            model.NewExercise.Time = "";
            model.NewExercise.Repetitions = 0;
            model.NewExercise.ID = 0;
            model.ErrorMessage = "";

            return View(model);
        }

        [HttpPost]
        public IActionResult NewExercise(NewExerciseModel model)
        {
            if (string.IsNullOrEmpty(model.NewExercise.Name) || string.IsNullOrEmpty(model.NewExercise.Description))
            {
                model.ErrorMessage = "Voer alle lege velden in A.U.B.";
            }
            else
            {
                ExerciseDAL exerciseDAL = new ExerciseDAL();
                TrainingLogic trainingLogic = new TrainingLogic();
                Exercise exercise = new();
                exercise.Name = model.NewExercise.Name;
                exercise.Description = model.NewExercise.Description;
                exercise.Time = model.NewExercise.Time;
                exercise.Repetitions = model.NewExercise.Repetitions;
                try
                {
                    if (!trainingLogic.AddExercise(exercise, exerciseDAL))
                    {
                        model.ErrorMessage = "Oefening toevoegen mislukt!";
                    }
                    else
                    {
                        model.SuccesMessage = "Oefening is toegevoegd!";
                    }
                }
                catch (ArgumentException)
                {
                    model.ErrorMessage = "Voer alle lege velden in A.U.B.";
                }
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
