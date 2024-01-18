using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmTutorial.Model;
using WpfMvvmTutorial.MVVM;

namespace WpfMvvmTutorial.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute=> SelectedItem!=null);
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());
        public RelayCommand CollapseSideBar => new RelayCommand(execute => SwitchSideBarCollapsed(), canExecute => true);

        public MainWindowViewModel() 
        {
            Items = new ObservableCollection<Item>();
            SideBarCollapsed = true;
            CollapseButtonContent = " < ";

        }

        private Item _selectedItem;
        public Item SelectedItem
        { 
            get => _selectedItem;  
            set 
            { 
                _selectedItem = value;
                OnPropertyChanged();
            } 
        }
        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                OnPropertyChanged();
            }
        }

        private void AddItem()
        {
            Items.Add(new Item
            {
                Name="New Item",
                SerialNumber="XXXXX",
                Quantity=0,
            });
        }

        private void DeleteItem()
        {
            Items.Remove(_selectedItem);
        }

        private void Save()
        {
            // save to file or db
        }
        private bool CanSave()
        {
            return true;
        }

        private void SwitchSideBarCollapsed()
        {
            SideBarCollapsed = !SideBarCollapsed;
            if (SideBarCollapsed) 
            {
                CollapseButtonContent = " < ";
            }
            else
            {
                CollapseButtonContent = " > ";
            }
        }


        private bool _sideBarCollapsed;
        public bool SideBarCollapsed
        {
            get => _sideBarCollapsed;
            set
            {
                _sideBarCollapsed = value;
                OnPropertyChanged();
            }
        }
        private string _collapseButtonContent;
        public string CollapseButtonContent
        {
            get => _collapseButtonContent;
            set
            {
                _collapseButtonContent = value;
                OnPropertyChanged();
            }
        }
    }
}
