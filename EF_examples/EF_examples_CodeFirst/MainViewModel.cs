using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EF_examples_CodeFirst
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private List<Student> students;
        StudentRepository studentRepository = new StudentRepository();
        ScoreRepository scoreRepository = new ScoreRepository();
        private Student selectedStudent;
        private List<Score> scores;

        public ActionCommand AddStudentCommand { get; set; }
        public ActionCommand AddScoreCommand { get; set; }

        public string StudentName { get; set; }
        public int Score { get; set; }
        public List<Score> Scores
        {
            get => scores;
            set
            {
                scores = value;
                OnPropertyChanged();
            }
        }
        public List<Student> Students
        {
            get => students;
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                LoadScores(value);
            }
        }

        private void LoadScores(Student value)
        {
            Scores = scoreRepository.GetScoresForStudent(value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            AddStudentCommand = new ActionCommand(AddStudentCommandAction);
            AddScoreCommand = new ActionCommand(AddScoreCommandAction);
            Students = studentRepository.GetAllStudents();
        }

        private void AddScoreCommandAction()
        {
            scoreRepository.AddScoreForStudent(Score, SelectedStudent);
            LoadScores(SelectedStudent);
        }

        private void AddStudentCommandAction()
        {
            studentRepository.CreateStudent(StudentName);

            Students = studentRepository.GetAllStudents();
        }

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
