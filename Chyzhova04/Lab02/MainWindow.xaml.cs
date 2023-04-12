using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using System;
using System.Windows.Controls;

namespace Lab02
{
    public partial class MainWindow : Window
    {
        private PersonRepository _personRepository;
        public MainWindow()
        {
            InitializeComponent();
            _personRepository = new PersonRepository();
            _personRepository.LoadData();
            LoadDataGrid();
            PersonsDataGrid.ItemsSource = _personRepository.GetAll();
        }

        private void SortAndFilterData(string propertyName, ListSortDirection sortDirection, string filterText)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(PersonsDataGrid.ItemsSource);
            collectionView.SortDescriptions.Clear();
            collectionView.SortDescriptions.Add(new SortDescription(propertyName, sortDirection));
            collectionView.Filter = item =>
            {
                Person person = item as Person;
                if (string.IsNullOrEmpty(filterText))
                {
                    return true;
                }
                return person.FirstName.Contains(filterText) || person.LastName.Contains(filterText) || person.Email.Contains(filterText);
            };
        }

        private void ApplySortingAndFiltering()
        {
            string propertyName = "FirstName"; // Replace with the actual property name
            ListSortDirection sortDirection = ListSortDirection.Ascending; // Replace with the actual sort direction
            string filterText = ""; // Replace with the actual filter text

            SortAndFilterData(propertyName, sortDirection, filterText);
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            Person newPerson = new Person();
            PersonEditWindow personEditWindow = new PersonEditWindow(newPerson);

            if (personEditWindow.ShowDialog() == true)
            {
                _personRepository.Add(newPerson);
                LoadDataGrid();
            }
        }

        private void LoadDataGrid()
        {
            var persons = _personRepository.GetAll();

            // Встановлюємо джерело даних для DataGrid
            PersonsDataGrid.ItemsSource = persons;
            // PersonsDataGrid.ItemsSource = _personRepository.GetAll();
        }

        private void EditPersonButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonsDataGrid.SelectedItem is Person selectedPerson)
            {
                PersonEditWindow personEditWindow = new PersonEditWindow(selectedPerson);

                if (personEditWindow.ShowDialog() == true)
                {
                    _personRepository.Update(selectedPerson);
                    LoadDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a person to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeletePersonButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonsDataGrid.SelectedItem != null)
            {
                Person selectedPerson = PersonsDataGrid.SelectedItem as Person;

                if (selectedPerson != null)
                {
                    _personRepository.Delete(selectedPerson.Id);

                    // Оновлюємо DataGrid, щоб показати оновлені дані
                    LoadDataGrid();
                }
            }
        }
    }
}
