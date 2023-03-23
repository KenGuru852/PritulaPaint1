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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Avalonia.Input.Raw;
using Avalonia.Input;
using JetBrains.Annotations;
using Avalonia.Media;
using DynamicData.Binding;
using System.Collections.Specialized;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;
using Path = System.IO.Path;

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
        private ObservableCollection<Figure> allFigure;

        public ObservableCollection<Figure> AllFigure
        {
            get { return allFigure; }
            set { this.RaiseAndSetIfChanged(ref allFigure, value); }
        }

        private ObservableCollection<Figure> allFigureLoader;

        public ObservableCollection<Figure> AllFigureLoader
        {
            get { return allFigureLoader; }
            set { this.RaiseAndSetIfChanged(ref allFigureLoader, value); }
        }

        public ObservableCollection<MultipleCorners> MultipleCornersFig
        {
            get { return multipleCornersFig; }
            set { this.RaiseAndSetIfChanged(ref multipleCornersFig, value); }
        }

        public MainWindowViewModel()
        {
            // DeleteButton = ReactiveCommand.Create<Unit, Unit>(_ => { RemoveButton(); return new Unit(); });
            AllFigure = new ObservableCollection<Figure>();
            AllFigureLoader = new ObservableCollection<Figure>();
            content = allContent[0];
            ListBoxSelectedIndex = -1;
            CommandFormat = Formats[0];
            //LoadFigures()
            xmlsavers = new XMLSaver();
            xmlloaders = new XMLLoader();
            jsonsavers = new JSONSaver();
            jsonloaders = new JSONLoader();
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
            set { this.RaiseAndSetIfChanged(ref Choosing, value); 
                Content = allContent[value];
                CommandFormat = Formats[SelectedFigure];
            }
        }

        private string commandFormat;
        public string CommandFormat
        {
            get { return commandFormat; }
            set { this.RaiseAndSetIfChanged(ref commandFormat, value); }
        }

        public UserControl Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }

        string[] Formats = { "Точки: X Y", "Точки: X Y,X Y,X Y", "Точки: X Y,X Y,X Y", "Начальная точка: X Y\nШирина: W\nВысота: Н", "Начальная точка: X Y\nШирина: W\nВысота: H", "" };

        string[] Colors = { "Red", "Yellow", "Blue", "Green", "Black" };

        public void AddLine()
        {
            Debug.WriteLine(ListBoxSelectedIndex);
            bool check = true;
            for (int i = 0; i < AllFigure.Count; i++)
            {
                if (Name == AllFigure[i].Name)
                {
                    check = false;
                }
            }
            if (ListBoxSelectedIndex == -1)
            {
                if (check)
                {
                    if (Choosing == 0)
                    {
                        //AllFigure.Add(new Line { Name = _Name, LineXPoint = FirstPoint, LineYPoint = SecondPoint, LineThickness = lineThickness, LineColor = Colors[SelectedBoxIndex] });
                        AllFigure.Add(new Line(_Name, FirstPoint, SecondPoint, lineThickness, Colors[SelectedBoxIndex]));
                    }
                    if (Choosing == 1)
                    {
                        AllFigure.Add(new BrokenLine(_Name, _BrokenPoints, lineThickness, Colors[SelectedBoxIndex]));
                    }
                    if (Choosing == 2)
                    {
                        AllFigure.Add(new MultipleCorners(_Name, _BrokenPoints, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex]));
                    }
                    if (Choosing == 3)
                    {
                        AllFigure.Add(new RectangleClass(_Name, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex], _Height, _Width, _FirstPoint));
                    }
                    if (Choosing == 4)
                    {
                        AllFigure.Add(new EllipseFigure(_Name, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex], _Height, _Width, _FirstPoint));
                    }
                    if (Choosing == 5)
                    {
                        AllFigure.Add(new MixLineClass(_Name, _MixCommands, lineThickness, Colors[SelectedBoxIndex], Colors[_SelectedFillIndex]));
                    }
                    //Debug.WriteLine(BrokenPoints);
                    //Debug.WriteLine(ListBoxSelectedIndex);
                }
            }
            else
            {
                //AllFigure[0].Name = "RUHID";
                Editor(ListBoxSelectedIndex);
                //Debug.WriteLine(AllFigure[ListBoxSelectedIndex].Name);
                
            }
        }

        private void Editor (int Index)
        {
            string NewName = Name;
            string NewColor = Colors[SelectedBoxIndex];
            int NewThickness = lineThickness;

            if (Choosing == 0)
            {
                //Point NewXPoint = Point.Parse(FirstPoint);
                //Point NewYPoint = Point.Parse(SecondPoint);
                AllFigure.Add(new Line(_Name, FirstPoint, SecondPoint, lineThickness, Colors[SelectedBoxIndex]));
            }

            if (Choosing == 1)
            {
               string NewFigurePoint = BrokenPoints;
               AllFigure.Add(new BrokenLine(NewName, NewFigurePoint, NewThickness, NewColor));
            }
            if (Choosing == 2)
            {
                string NewFigurePoint = BrokenPoints;
                string NewFillColor = Colors[SelectedFillIndex];
                string NewWidth = Width;
                AllFigure.Add(new MultipleCorners(NewName, NewFigurePoint, NewThickness, NewColor, NewFillColor));
            }
            if (Choosing == 3)
            {
                string NewFigurePoint = FirstPoint;
                string NewFillColor =  Colors[SelectedFillIndex];
                string NewWidth = Width;
                string NewHeight = Height;
                AllFigure.Add(new RectangleClass(NewName, NewThickness, NewColor, NewFillColor, NewHeight, NewWidth, NewFigurePoint));
            }
            if (Choosing == 4)
            {
                string NewFigurePoint = FirstPoint;
                string NewFillColor = Colors[SelectedFillIndex];
                string NewWidth = Width;
                string NewHeight = Height;
                AllFigure.Add(new EllipseFigure(NewName, NewThickness, NewColor, NewFillColor, NewHeight, NewWidth, NewFigurePoint));
            }
            if (Choosing == 5)
            {
                string NewFillColor = Colors[SelectedFillIndex];
                string NewCommands = MixCommands;
                AllFigure.Add(new MixLineClass(NewName, NewCommands, NewThickness, NewColor, NewFillColor));
            }
            AllFigure.RemoveAt(Index);
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

        private string _Width;
        public string Width
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

        private string _Height;
        public string Height
        {
            get => _Height;
            set
            {
                this.RaiseAndSetIfChanged(ref _Height, value);
            }

        }

        public void RemoveButton()
        {
            if (ListBoxSelectedIndex != -1)
            {
                AllFigure.RemoveAt(ListBoxSelectedIndex);
            }
        }

        private bool _ButtonActive;
        public bool ButtonActive
        {
            get => _ButtonActive;
            set
            {
                this.RaiseAndSetIfChanged(ref _ButtonActive, value);
            }
        }

        private bool _AddButtonActives;
        public bool AddButtonActives
        {
            get => _AddButtonActives;
            set
            {
                this.RaiseAndSetIfChanged(ref _AddButtonActives, value);
            }
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
            ListBoxSelectedIndex = -1;
            Name = "";
            BrokenPoints = "";
            FirstPoint = "0, 0";
            SecondPoint = "0, 0";
            Width = "0";
            Height = "0";
            SelectedFillIndex = 0;
            lineThickness = 0;
            SelectedBoxIndex = 0;
            MixCommands = "";
        }

        private int FindColor (string ColorName)
        {
            for (int i = 0; i < Colors.Length; i++)
            {
                if (ColorName == Colors[i])
                {
                    return i;
                }
            }
            return 0;
        }

        // "BrokenLine" "Ellipse" "Line" "MixLine" "MultipleCorners" "Rectangle"
        public void ChangeParametr(int Index)
        {
            Name = AllFigure[Index].Name;
            SelectedBoxIndex = FindColor(AllFigure[Index].LineColor);
            lineThickness = AllFigure[Index].LineThickness;

            if (AllFigure[Index].FigureType == "Line")
            {
                SelectedFigure = 0;
                FirstPoint = AllFigure[Index].XPoint.ToString();
                SecondPoint = AllFigure[Index].YPoint.ToString();
            }
            if (AllFigure[Index].FigureType == "BrokenLine")
            {
                SelectedFigure = 1;
                BrokenPoints = AllFigure[Index].FigurePoint;
            }
            if (AllFigure[Index].FigureType == "MultipleCorners")
            {
                SelectedFigure = 2;
                BrokenPoints = AllFigure[Index].FigurePoint;
                SelectedFillIndex = FindColor(AllFigure[Index].FillColor);
            }
            if (AllFigure[Index].FigureType == "Rectangle")
            {
                SelectedFigure = 3;
                FirstPoint = AllFigure[Index].FigurePoint;
                SelectedFillIndex = FindColor(AllFigure[Index].FillColor);
                Width = AllFigure[Index].Width.ToString();
                Height = AllFigure[Index].Height.ToString();
            }
            if (AllFigure[Index].FigureType == "Ellipse")
            {
                SelectedFigure = 4;
                FirstPoint = AllFigure[Index].FigurePoint;
                SelectedFillIndex = FindColor(AllFigure[Index].FillColor);
                Width = AllFigure[Index].Width.ToString();
                Height = AllFigure[Index].Height.ToString();
            }
            if (AllFigure[Index].FigureType == "MixLine")
            {
                SelectedFigure = 5;
                SelectedFillIndex = FindColor(AllFigure[Index].FillColor);
                MixCommands = AllFigure[Index].Commands;
            }
        }


        private int _ListBoxSelectedIndex;
        public int ListBoxSelectedIndex
        {
            get => _ListBoxSelectedIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _ListBoxSelectedIndex, value);

                if (ListBoxSelectedIndex == -1)
                {
                    Name = "";
                    lineThickness = 0;
                    FirstPoint = "";
                    SecondPoint = "";
                    SelectedBoxIndex = 0;
                }
                else
                {
                    ChangeParametr(ListBoxSelectedIndex);
                }
         /*       else
                {
                    ButtonActive = true;
                    AllFigure[ListBoxSelectedIndex].ActiveButton = true;
                   for (int i = 0; i < AllFigure.Count; i++)
                    {
                        if (i == ListBoxSelectedIndex)
                        {
                            continue;
                        }
                        else
                        {
                            AllFigure[i].ActiveButton = false;
                        }
                    }
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
                }*/
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
        public IEnumerable<ISaverLoaderFactory> SaverLoaderFactoryCollection { get; set; }

        public XMLSaver xmlsavers;

        public XMLLoader xmlloaders;

        public JSONSaver jsonsavers;

        public JSONLoader jsonloaders;
        public void SaveFigures(string path)
        {
            if (Path.GetExtension(path) == ".xml")
            {
                xmlsavers.Save(AllFigure, path);
            }
            if (Path.GetExtension(path) == ".json")
            //  jsonsavers.Save(AllFigure, path);
            {
                jsonsavers.Save(AllFigure, path);
            }
            //figureSaver =  SaverLoaderFactoryCollection.FirstOrDefault(factory => factory.IsMatch(path) == true)?.CreateSaver();
            //if (figureSaver != null)
            //{
             //   figureSaver.Save(AllFigure, path);
            //}
        }

        public void LoadFigures(string path)
        {
            if (Path.GetExtension(path) == ".xml")
            {
                AllFigure = new ObservableCollection<Figure>(xmlloaders.Load(path));
            }
            if (Path.GetExtension(path) == ".json")
            {
                AllFigure = new ObservableCollection<Figure>(jsonloaders.Load(path));
                for (int i = 0; i < AllFigure.Count; i++)
                {
                    ListBoxSelectedIndex = 0;
                    AddLine();
                }
            }
            //var figureLoader = SaverLoaderFactoryCollection.FirstOrDefault(factory => factory.IsMatch(path) == true)?.CreateLoader();
            // AllFigure = new ObservableCollection<Figure>(xmlloaders.Load(path));
           // AllFigure = new ObservableCollection<Figure>(figureLoader.Load(path));
            //for (int i = 0; i < AllFigure.Count; i++)
            //{
              //  ListBoxSelectedIndex = 0;
                //AddLine();
            //}
        }
    }
}

//Не импортируются точки в JSON формате