using System;
using System.Collections.ObjectModel;
using AvaloniaApplication10.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication10.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _outputText = string.Empty;
        private LivingCreature? _selectedCreature = null;
        
        public ObservableCollection<LivingCreature> Creatures { get; } = new();
        public ObservableCollection<string> ActionsHistory { get; } = new();

        public LivingCreature? SelectedCreature
        {
            get => _selectedCreature;
            set
            {
                _selectedCreature = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanRoar));
                OnPropertyChanged(nameof(CanClimbTree));
            }
        }

        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;
                OnPropertyChanged();
            }
        }

        public bool CanRoar => SelectedCreature is Panther or Dog;
        public bool CanClimbTree => SelectedCreature is Panther;

        public MainWindowViewModel()
        {
            // Инициализация существ
            Creatures.Add(new Panther("Пантера"));
            Creatures.Add(new Dog("Собака"));
            Creatures.Add(new Turtle("Черепаха"));

            // Подписка на события
            foreach (var creature in Creatures)
            {
                if (creature is Panther panther)
                {
                    panther.RoarEvent += message => 
                    {
                        OutputText = message;
                        ActionsHistory.Add(message);
                    };
                }
                
                if (creature is Dog dog)
                {
                    dog.BarkEvent += message => 
                    {
                        OutputText = message;
                        ActionsHistory.Add(message);
                    };
                }
            }
        }

        public void MoveCreature()
        {
            if (SelectedCreature == null) return;
            
            SelectedCreature.Move();
            var message = $"{SelectedCreature.Name} движется со скоростью {SelectedCreature.CurrentSpeed}";
            OutputText = message;
            ActionsHistory.Add(message);
            
            OnPropertyChanged(nameof(SelectedCreature));
        }

        public void StopCreature()
        {
            if (SelectedCreature == null) return;
            
            SelectedCreature.Stop();
            var message = $"{SelectedCreature.Name} замедляется до {SelectedCreature.CurrentSpeed}";
            OutputText = message;
            ActionsHistory.Add(message);
            
            OnPropertyChanged(nameof(SelectedCreature));
        }

        public void MakeSound()
        {
            if (SelectedCreature is Panther panther)
            {
                panther.Roar();
            }
            else if (SelectedCreature is Dog dog)
            {
                dog.Bark();
            }
        }

        public void ToggleTreeClimbing()
        {
            if (SelectedCreature is not Panther panther) return;
            
            if (panther.IsOnTree)
            {
                panther.DescendFromTree();
                var message = $"{panther.Name} спускается с дерева";
                OutputText = message;
                ActionsHistory.Add(message);
            }
            else
            {
                panther.ClimbTree();
                var message = $"{panther.Name} залезает на дерево";
                OutputText = message;
                ActionsHistory.Add(message);
            }
            
            OnPropertyChanged(nameof(SelectedCreature));
        }
    }
}