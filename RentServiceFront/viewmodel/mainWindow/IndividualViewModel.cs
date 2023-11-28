using System.Collections.Generic;

namespace RentServiceFront.viewmodel.mainWindow;

public class IndividualViewModel : ViewModelBase
{
    private List<PassportViewModel> _passports;

    public IndividualViewModel(List<PassportViewModel> passports)
    {
        _passports = passports;
    } 
    public List<PassportViewModel> Passports
    {
        get => _passports;
        set
        {
            _passports = value;
            OnPropertyChange(nameof(Passports));
        }
    }
}