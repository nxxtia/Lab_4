using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab02
{
    public partial class PersonEditWindow : Window
    {
        private Person _person;

        public PersonEditWindow(Person person)
        {
            InitializeComponent();

            _person = person;

            FirstNameTextBox.Text = _person.FirstName;
            LastNameTextBox.Text = _person.LastName;
            EmailTextBox.Text = _person.Email;
            DateOfBirthPicker.SelectedDate = _person.DateOfBirth;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Update person properties from the controls
            _person.FirstName = FirstNameTextBox.Text;
            _person.LastName = LastNameTextBox.Text;
            _person.Email = EmailTextBox.Text;
            _person.DateOfBirth = DateOfBirthPicker.SelectedDate.Value;

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
