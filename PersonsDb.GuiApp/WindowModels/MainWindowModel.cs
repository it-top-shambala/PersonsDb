using System.Collections.ObjectModel;
using System.Windows;
using PersonsDb.DbLib;
using PersonsDb.GuiApp.Commands;

namespace PersonsDb.GuiApp.WindowModels;

public class MainWindowModel : WindowModelBase
{
    private readonly PersonsDbContext _db;
    public ObservableCollection<Person> Persons { get; set; }

    private Person? _selectedPerson;
    public Person? SelectedPerson
    {
        get => _selectedPerson; 
        set => SetField(ref _selectedPerson, value);
    }

    public LambdaCommand DeleteCommand { get; set; }
    public LambdaCommand SaveCommand { get; set; }

    public MainWindowModel()
    {
        var connectionString = Application.Current.Resources["ConnectionString"] as string;
        _db = new PersonsDbContext(connectionString!);
        Persons = new ObservableCollection<Person>(_db.Persons);

        DeleteCommand = new LambdaCommand(
            execute: () =>
            {
                Persons.Remove(SelectedPerson);
                _db.Persons.Remove(SelectedPerson);
                _db.SaveChanges();
            },
            canExecute: () => SelectedPerson is not null);
        SaveCommand = new LambdaCommand(
            execute: () =>
            {
                Persons.Add(SelectedPerson);
                _db.Persons.Add(SelectedPerson);
                _db.SaveChanges();
            },
            canExecute: () => SelectedPerson is not null);
    }
}