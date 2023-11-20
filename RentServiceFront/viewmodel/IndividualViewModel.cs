using System.Collections.Generic;

namespace RentServiceFront.viewmodel;

public class IndividualViewModel : ViewModelBase
{
    private List<PassportViewModel> _passports;

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