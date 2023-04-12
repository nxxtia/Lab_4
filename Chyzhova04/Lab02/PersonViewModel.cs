using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab02
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth;
        private ICommand _proceedCommand;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
                    }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string OutputText
        {
            get { return _outputText; }
            set
            {
                _outputText = value;
                OnPropertyChanged(nameof(OutputText));
            }
        }
        private string _outputText;


        public ICommand ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand(async (x) =>
                {
                    if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Email))
                    {
                        MessageBox.Show("All fields must be filled out.");
                        return;
                    }

                    if (_dateOfBirth == default(DateTime))
                    {
                        MessageBox.Show("Please enter a valid date of birth.");
                        return;
                    }

                    int age = CalculateAge();

                    try { 
                        _person = new Person(FirstName, LastName, Email, DateOfBirth);
                        bool isDataValid = await CheckDataAsync();

                        if (isDataValid)
                        {
                            OutputText = $"Name: {_person.FirstName} {_person.LastName}\n" +
                                         $"Email: {_person.Email}\n" +
                                         $"Date of Birth: {_person.DateOfBirth.ToShortDateString()}\n" +
                                         $"Is Adult: {_person.IsAdult}\n" +
                                        $"Sun Sign: {_person.SunSign}\n" +
                                         $"Chinese Sign: {_person.ChineseSign}\n" +
                                         $"Is Birthday: {_person.IsBirthday}";

                            if (_person.IsBirthday)
                            {
                                MessageBox.Show("Happy Birthday!");
                            }
                        }
                    }
                    catch (FutureBirthDateException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (DistantPastBirthDateException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (InvalidEmailException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (InvalidFirstNameException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    catch (InvalidLastNameException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                }));
            }
        }

        private int CalculateAge()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                age -= 1;

            return age;
        }

        private async Task<bool> CheckDataAsync()
        {
            if (_person.DateOfBirth > DateTime.Now || _person.DateOfBirth.AddYears(135) < DateTime.Now)
            {
                MessageBox.Show("Incorrect date of birth. Please, check the input.");
                return false;
            }
            await Task.Delay(1000);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
    }
}
