using System.Collections.ObjectModel;
using ReactiveUI;
using Paint.Models;
using Avalonia;
using System.Xml.Linq;
using DynamicData;
using Avalonia.Controls.Shapes;
using Paint.ViewModels;
using Line = Paint.Models.Line;
using System.Drawing.Text;
using Avalonia.Controls;
using Paint.Views;
using System.Diagnostics;
using System.Reactive;

namespace Paint.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public int Choosing = 0;
        private ObservableCollection<Line> lines;
        private ObservableCollection<BrokenLine> brokenLines;
        private ObservableCollection<MultipleCorners> multipleCornersFig;
        private ObservableCollection<RectangleClass> recFigures;
        private ObservableCollection<EllipseFigure> ellipseFigures;
        private ObservableCollection<MixLineClass> mixLineFigures;

        public ObservableCollection<MixLineClass> MixLineFigures
        {
            get { return mixLineFigures; }
            set { this.RaiseAndSetIfChanged(ref mixLineFigures, value); }
        }

        public ObservableCollection<EllipseFigure> EllipseFigures
        {
            get { return ellipseFigures; }
            set { this.RaiseAndSetIfChanged(ref ellipseFigures, value); }
        }

        public ObservableCollection<RectangleClass> RecFigures
        {
            get { return recFigures; }
            set { this.RaiseAndSetIfChanged(ref recFigures, value); }
        }
        private ObservableCollection<Line> allFigure;

        public ObservableCollection<Line> AllFigure
        {
            get { return allFigure; }
            set { this.RaiseAndSetIfChanged(ref allFigure, value); }
        }

        public ObservableCollection<MultipleCorners> MultipleCornersFig
        {
            get { return multipleCornersFig; }
            set { this.RaiseAndSetIfChanged(ref multipleCornersFig, value); }
        }

        public MainWindowViewModel()
        {
           // DeleteButton = ReactiveCommand.Create<Unit, Unit>(_ => { RemoveButton(); return new Unit(); });
            Lines = new ObservableCollection<Line>();
            BrokenLines = new ObservableCollection<BrokenLine>();
            MultipleCornersFig = new ObservableCollection<MultipleCorners>();
            RecFigures = new ObservableCollection<RectangleClass>();
            EllipseFigures = new ObservableCollection<EllipseFigure>();
            MixLineFigures = new ObservableCollection<MixLineClass>();
            AllFigure = new ObservableCollection<Line>();
            content = allContent[0];

        }

       // public ReactiveCommand<Unit, Unit> DeleteButton { get; }

        private UserControl content;

        private readonly UserControl[] allContent = new UserControl[]
        {
            new LineUserControl(),
            new BrokenLineUserControl(),
            new MultipleCornersUserControl(),
            new RectangleFigureUserControl(),
            new EllpseFigureUserControl(),
            new MixLineUserControl()
        };

        public int SelectedFigure
        {
            get => Choosing;
            set { this.RaiseAndSetIfChanged(ref Choosing, value); Content = allContent[value]; }
        }

        public UserControl Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }

        string[] Colors = { "Red", "Yellow", "Blue", "Green", "Black" };

        public void AddLine()
        {
            if (Choosing == 0)
            {
                Lines.Add(new Line { Name = _Name, XPoint = Point.Parse(_FirstPoint), YPoint = Point.Parse(_SecondPoint), LineThickness = lineThickness, LineColor = Colors[SelectedBoxIndex] });
                AllFigure.Add(new Line { Name = _Name, XPoint = Point.Parse(_FirstPoint), YPoint = Point.Parse(_SecondPoint), LineThickness = lineThickness, LineColor = Colors[SelectedBoxIndex] });
            }
            if (Choosing == 1)
            {
                BrokenLines.Add(new BrokenLine (_Name, _BrokenPoints, lineThickness, Colors[SelectedBoxIndex] ));
                AllFigure.Add(new BrokenLine(_Name, _BrokenPoints, lineThickness, Colors[SelectedBoxIndex]));
            }
            if (Choosing == 2)
            {
                MultipleCornersFig.Add(new MultipleCorners(_Name, _BrokenPoints, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex]));
                AllFigure.Add(new MultipleCorners(_Name, _BrokenPoints, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex]));
            }
            if (Choosing == 3)
            {
                RecFigures.Add(new RectangleClass(_Name, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex], _Height, _Width, _FirstPoint));
                AllFigure.Add(new RectangleClass(_Name, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex], _Height, _Width, _FirstPoint));
            }
            if (Choosing == 4)
            {
                EllipseFigures.Add(new EllipseFigure(_Name, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex], _Height, _Width, _FirstPoint));
                AllFigure.Add(new EllipseFigure(_Name, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex], _Height, _Width, _FirstPoint));
            }
            if (Choosing == 5)
            {
                MixLineFigures.Add(new MixLineClass(_Name, _MixCommands, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex]));
                AllFigure.Add(new MixLineClass(_Name, _MixCommands, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex]));
            }
            Debug.WriteLine(BrokenPoints);
            Debug.WriteLine(ListBoxSelectedIndex);
        }

        private string _MixCommands;
        public string MixCommands
        {
            get => _MixCommands;
            set
            {
                this.RaiseAndSetIfChanged(ref _MixCommands, value);
            }

        }

        private int _Width;
        public int Width
        {
            get => _Width;
            set
            {
                this.RaiseAndSetIfChanged(ref _Width, value);
            }

        }

        private string _StartPoint;
        public string StartPoint
        {
            get => _StartPoint;
            set
            {
                this.RaiseAndSetIfChanged(ref _StartPoint, value);
            }

        }

        private int _Height;
        public int Height
        {
            get => _Height;
            set
            {
                this.RaiseAndSetIfChanged(ref _Height, value);
            }

        }

        public void RemoveButton()
        {
            AllFigure.RemoveAt(ListBoxSelectedIndex);
        }


        private int _SelectedIndex;
        public int SelectedIndex
        {
            get => _SelectedIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedIndex, value);
            }

        }

        private int _SelectedFillIndex;
        public int SelectedFillIndex
        {
            get => _SelectedFillIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedFillIndex, value);
            }

        }

        private int _SelectedBoxIndex;
        public int SelectedBoxIndex
        {
            get => _SelectedBoxIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedBoxIndex, value);
            }

        }

        public void ResetButton()
        {
            Name = " ";
            BrokenPoints = " ";
            FirstPoint = "0, 0";
            SecondPoint = "0, 0";
            Width = 0;
            Height = 0;
            SelectedFillIndex = 0;
            lineThickness = 0;
            SelectedBoxIndex = 0;
            MixCommands = "";
        }



        private int _ListBoxSelectedIndex;
        public int ListBoxSelectedIndex
        {
            get => _ListBoxSelectedIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _ListBoxSelectedIndex, value);
                Debug.WriteLine(ListBoxSelectedIndex);
                Name = AllFigure[ListBoxSelectedIndex].Name;
                lineThickness = AllFigure[ListBoxSelectedIndex].LineThickness;
                FirstPoint = AllFigure[ListBoxSelectedIndex].XPoint.ToString();
                SecondPoint = AllFigure[ListBoxSelectedIndex].YPoint.ToString();
                string TempColor = "";
                TempColor = AllFigure[ListBoxSelectedIndex].LineColor;
                int TempPoint = 0;
                foreach (var item in Colors)
                {
                    if (Colors[TempPoint] == TempColor)
                    {
                        break;
                    }
                    else TempPoint++;
                }
                SelectedBoxIndex = TempPoint;
                MixCommands = "";
            }

        }
        private int _lineThickness;
        public int lineThickness
        {
            get => _lineThickness;
            set
            {
                this.RaiseAndSetIfChanged(ref _lineThickness, value);
            }

        }

        public ObservableCollection<Line> Lines
        {
            get { return lines; }
            set { this.RaiseAndSetIfChanged(ref lines, value); }
        }

        public ObservableCollection<BrokenLine> BrokenLines
        {
            get { return brokenLines; }
            set { this.RaiseAndSetIfChanged(ref brokenLines, value); }
        }

        private string _FirstPoint;
        public string FirstPoint
        {
            get => _FirstPoint;
            set
            {
                this.RaiseAndSetIfChanged(ref _FirstPoint, value);
            }

        }

        private string _BrokenPoints;
        public string BrokenPoints
        {
            get => _BrokenPoints;
            set
            {
                this.RaiseAndSetIfChanged(ref _BrokenPoints, value);
            }

        }

        private string _SecondPoint;
        public string SecondPoint
        {
            get => _SecondPoint;
            set
            {
                this.RaiseAndSetIfChanged(ref _SecondPoint, value);
            }

        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                this.RaiseAndSetIfChanged(ref _Name, value);
            }

        }
    }
}