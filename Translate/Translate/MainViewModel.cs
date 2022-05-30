using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Translate
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string text;
        private bool option1Selected;
        private bool option2Selected;
        private bool option3Selected;
        private bool option4Selected;


        ITranslatable translater = null;
        public bool Option1Selected
        {
            get
            {
                return option1Selected;
            }
            set
            {
                option1Selected = value;
                if (option1Selected)
                {
                    translater = new NLTranslater();
                }
            }
        }
        public bool Option2Selected
        {
            get
            {
                return option2Selected;
            }
            set
            {
                option2Selected = value;
                if (option2Selected)
                {
                    translater = new FRTranslater();
                }
            }
        }
        public bool Option3Selected
        {
            get
            {
                return option3Selected;
            }
            set
            {
                option3Selected = value;
                if (option3Selected)
                {
                    translater = new ENTranslater();
                }
            }
        }

        public bool Option4Selected
        {
            get
            {
                return option4Selected;
            }
            set
            {
                option4Selected = value;
                if (option4Selected)
                {
                    translater = new ESTranslater();
                }
            }
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ActionCommand TranslateCommand { get; set; }

        public MainViewModel()
        {
            Option1Selected = true;
            TranslateCommand = new ActionCommand(TranslateCommandAction);
        }

        private void TranslateCommandAction()
        {
            Text = translater.Translate();
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
